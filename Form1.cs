using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Weatherwane
{
    public partial class Form1 : Form
    {
        FacadeViewer facade;
        List<Primitive> primitives;
        Primitive primitive;
        

        Vec3d V = new Vec3d(0, 0, 0);
        public Form1()
        {
            InitializeComponent();

            this.facade = new FacadeViewer(canvas.Width, canvas.Height);
            {
                Command command = new LoadCommand("C:/msys64/home/alena/last_course/weatherwane.json");
                facade.executeCommand(command);

                render();
                UpdateLightsName();
                comboBoxLights.SelectedIndex = 1;
                GetCameraCommand getCameraCommand = new GetCameraCommand();
                facade.executeCommand(getCameraCommand);
                Camera tmp = getCameraCommand.getResult();
                CameraPosX.Text = tmp.position.x.ToString();
                CameraPosY.Text = tmp.position.y.ToString();
                CameraPosZ.Text = tmp.position.z.ToString();
                CameraRotOX.Text = tmp.angle.x.ToString();
                CameraRotOY.Text = tmp.angle.y.ToString();
                CameraRotOZ.Text = tmp.angle.z.ToString();
            }


            ToolStripMenuItem fileItem = new ToolStripMenuItem("Файл");
            ToolStripMenuItem loadItem = new ToolStripMenuItem("Загрузить");
            ToolStripMenuItem saveItem = new ToolStripMenuItem("Сохранить");

            
            fileItem.DropDownItems.Add(loadItem);
            fileItem.DropDownItems.Add(saveItem);

            openFileDialog1.Filter = "Text files(*.json)|*.json";
            saveFileDialog1.Filter = "Text files(*.json)|*.json";

            saveItem.Click += saveItem_Click;
            loadItem.Click += loadItem_Click;
            menuStrip1.Items.Add(fileItem);

            ToolStripMenuItem aboutItem = new ToolStripMenuItem("О программе");

            aboutItem.Click += aboutItem_Click;
            menuStrip1.Items.Add(aboutItem);

            dynamicButton.Click += dynamicButton_Click;

            render(); 
        }

        void render()
        {
            Command renderCommand = new RenderCommand(ref canvas, checkBoxNebo.Checked);
            
            facade.executeCommand(renderCommand);
        }

        void dynamicButton_Click(object sender, EventArgs e)
        {
            Command dynamicRenderCommand = new DynamicRenderCommand(ref canvas, checkBoxNebo.Checked, ref this.progressBar);

            facade.executeCommand(dynamicRenderCommand);
        }


        void saveItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            string filename = saveFileDialog1.FileName;
            Command saveCommand = new SaveCommand(filename);
            facade.executeCommand(saveCommand);
            MessageBox.Show("Сцена сохранена");    
        }

        void aboutItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа предназначена для моделирования вращения флюгера, состоящего из сфер, цилиндров, параллелепипедов и треугольных пирамид.");
        }


        void loadItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            string filename = openFileDialog1.FileName;

            try
            {
                Command loadCommand = new LoadCommand(filename);
                facade.executeCommand(loadCommand);
            }
            catch (Exception err)
            {
                MessageBox.Show("Ошибка загрузки сцены. Проверьте корректность содержания файля");
                return;
            }

            render();
            UpdateLightsName();
            comboBoxLights.SelectedIndex = 1;
            GetCameraCommand getCameraCommand = new GetCameraCommand();
            facade.executeCommand(getCameraCommand);
            Camera tmp = getCameraCommand.getResult();
            CameraPosX.Text = tmp.position.x.ToString();
            CameraPosY.Text = tmp.position.y.ToString();
            CameraPosZ.Text = tmp.position.z.ToString();
            CameraRotOX.Text = tmp.angle.x.ToString();
            CameraRotOY.Text = tmp.angle.y.ToString();
            CameraRotOZ.Text = tmp.angle.z.ToString();

            MessageBox.Show("Сцена загружена");

        }



        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                GetSceneObjectsCommand getSceneObjectsCommand = new GetSceneObjectsCommand();
                facade.executeCommand(getSceneObjectsCommand);

                primitives = getSceneObjectsCommand.getResult();

                choiceObject.Items.Clear();
                int flag = 0;
                
                
                for (int i = 0; i < primitives.Count; i++)
                {
                    if ((primitives[i] is Triangle) || (primitives[i] is DiskPlane))
                        continue;
                    
                    flag += 1;
                    choiceObject.Items.Add(primitives[i].name);
                    string tmp = (string)choiceObject.Items[flag - 1];
                    tmp = tmp.Replace("System.Windows.Forms.TextBox, Text: ", "");
                    choiceObject.Items[flag - 1] = tmp;
                }
                if (flag > 0)
                {
                    choiceObject.SelectedIndex = 0;
                    
                    ChoiceColor.Visible = true;
                    ChoiceReflective.Visible = true;
                    ChoiceSpecular.Visible = true;
                    labelChoiceReflective.Visible = true;
                    labelChoiceSpecular.Visible = true;
                    btnChange.Visible = true;

                    string selectedObject = this.choiceObject.SelectedItem.ToString();
                }
                
                else
                {
                    ChoiceColor.Visible = false;
                    ChoiceReflective.Visible = false;
                    ChoiceSpecular.Visible = false;
                    labelChoiceColor.Visible = false;
                    labelChoiceReflective.Visible = false;
                    labelChoiceSpecular.Visible = false;
                    btnChange.Visible = false;


                }    
                
            }
            if (tabControl1.SelectedIndex == 1)
            {
                GetSceneObjectsCommand getSceneObjectsCommand = new GetSceneObjectsCommand();
                facade.executeCommand(getSceneObjectsCommand);

                primitives = getSceneObjectsCommand.getResult();
                listBox1.Items.Clear();
                string str = "";
                int flag;
                for (int i = 0; i < primitives.Count; i++)
                {
                    flag = 0;
                    if (primitives[i] is Sphere)
                    {
                        Sphere tmp = (Sphere)primitives[i];
                        str = "Name: " + tmp.name + ", ";
                        str += "Type: Сфера, ";
                        str += "Вращается: " + tmp.moving + ", ";
                        str += "Parametrs: C = (" + tmp.C.x + "; " + tmp.C.y + "; " + tmp.C.z + "), ";
                        str += "R = " + tmp.radius + ", ";
                        str += "color = (" + tmp.color.x + "; " + tmp.color.y + "; " + tmp.color.z + "), ";
                        str += "specular = " + tmp.specular + ", ";
                        str += "reflective = " + tmp.reflective;
                        flag = 1;
                    }
                    else if (primitives[i] is Cylinder)
                    {
                        Cylinder tmp = (Cylinder)primitives[i];
                        str = "Name: " + tmp.name + ", ";
                        str += "Type: Цилиндр, ";
                        str += "Вращается: " + tmp.moving + ", ";
                        str += "Parametrs: Cосн = (" + tmp.C.x + "; " + tmp.C.y + "; " + tmp.C.z + "), ";
                        str += "Rосн = " + tmp.radius + ", ";
                        str += "V = (" + String.Format("{0:f6}", tmp.V.x) + "; " + String.Format("{0:f6}", tmp.V.y) + "; " + String.Format("{0:f6}", tmp.V.z) + "), ";
                        str += "H = " + tmp.maxm + ", ";
                        str += "color = (" + tmp.color.x + "; " + tmp.color.y + "; " + tmp.color.z + "), ";
                        str += "specular = " + tmp.specular + ", ";
                        str += "reflective = " + tmp.reflective;
                        flag = 1;
                    }
                    else if (primitives[i] is Parallelepiped)
                    {
                        Parallelepiped tmp = (Parallelepiped)primitives[i];
                        str = "Name: " + tmp.name + ", ";
                        str += "Type: Параллелепипед, ";
                        str += "Вращается: " + tmp.moving + ", ";
                        str += "Parametrs: С = (" + tmp.C.x + "; " + tmp.C.y + "; " + tmp.C.z + "), ";
                        str += "E = (" + tmp.E.x + "; " + tmp.E.y + "; " + tmp.E.z + "), ";
                        str += "color = (" + tmp.color.x + "; " + tmp.color.y + "; " + tmp.color.z + "), ";
                        str += "specular = " + tmp.specular + ", ";
                        str += "reflective = " + tmp.reflective;
                        flag = 1;
                    }
                    else if (primitives[i] is TrianglePyramid)
                    {
                        TrianglePyramid tmp = (TrianglePyramid)primitives[i];
                        str = "Name: " + tmp.name + ", ";
                        str += "Type: Пирамида, ";
                        str += "Вращается: " + tmp.moving + ", ";
                        str += "Parametrs: P = (" + tmp.P.x + "; " + tmp.P.y + "; " + tmp.P.z + "), ";
                        str += "A = (" + tmp.A.x + "; " + tmp.A.y + "; " + tmp.A.z + "), ";
                        str += "B = (" + tmp.B.x + "; " + tmp.B.y + "; " + tmp.B.z + "), ";
                        str += "C = (" + tmp.C.x + "; " + tmp.C.y + "; " + tmp.C.z + "), ";
                        str += "color = (" + tmp.color.x + "; " + tmp.color.y + "; " + tmp.color.z + "), ";
                        str += "specular = " + tmp.specular + ", ";
                        str += "reflective = " + tmp.reflective;
                        flag = 1;
                    }
                    else if (primitives[i] is Plane)
                    {
                        Plane tmp = (Plane)primitives[i];
                        str = "Name: " + tmp.name + ", ";
                        str += "Вращается: " + tmp.moving + ", ";
                        str += "color = (" + tmp.color.x + "; " + tmp.color.y + "; " + tmp.color.z + "), ";
                        str += "specular = " + tmp.specular + ", ";
                        str += "reflective = " + tmp.reflective;
                        flag = 1;
                    }
                    if (flag == 1)
                        listBox1.Items.Add(str);

                }

            }
        }

        private void buttonRollCamera_Click(object sender, EventArgs e)
        {
            if ((double)rollCamera.Value != 360 || (double)rollCamera.Value != -360)
            {
                Command rollCameraCommand = new RollCameraCommand((double)rollCamera.Value);
                facade.executeCommand(rollCameraCommand);

                render();
            }
            GetCameraCommand getCameraCommand = new GetCameraCommand();
            facade.executeCommand(getCameraCommand);
            Camera camera = getCameraCommand.getResult();


            CameraRotOZ.Text = camera.angle.z.ToString();
        }

        private void buttonYawCamera_Click(object sender, EventArgs e)
        {
            if ((double)yawCamera.Value != 360 || (double)yawCamera.Value != -360)
            {
                Command yawCameraCommand = new YawCameraCommand((double)yawCamera.Value);
                facade.executeCommand(yawCameraCommand);

                render();
            }
            GetCameraCommand getCameraCommand = new GetCameraCommand();
            facade.executeCommand(getCameraCommand);
            Camera camera = getCameraCommand.getResult();


            CameraRotOX.Text = camera.angle.x.ToString();
        }

        private void buttonPitchCamera_Click(object sender, EventArgs e)
        {
            if ((double)pitchCamera.Value != 360 || (double)pitchCamera.Value != -360)
            {
                Command pitchCameraCommand = new PitchCameraCommand((double)pitchCamera.Value);
                facade.executeCommand(pitchCameraCommand);

                render();
            }
            GetCameraCommand getCameraCommand = new GetCameraCommand();
            facade.executeCommand(getCameraCommand);
            Camera camera = getCameraCommand.getResult();
            
            
            CameraRotOY.Text = camera.angle.y.ToString();
            
        }

        private void buttonMoveCamera_Click(object sender, EventArgs e)
        {

            Command moveCameraCommand = new MoveCameraCommand((double)moveCameraDX.Value, (double)moveCameraDY.Value, (double)moveCameraDZ.Value);
            facade.executeCommand(moveCameraCommand);

            
            render();
            GetCameraCommand getCameraCommand = new GetCameraCommand();
            facade.executeCommand(getCameraCommand);
            Camera camera = getCameraCommand.getResult();
            CameraPosX.Text = camera.position.x.ToString();
            CameraPosY.Text = camera.position.y.ToString();
            CameraPosZ.Text = camera.position.z.ToString();

        }

        private void choiceObject_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedObject = this.choiceObject.SelectedItem.ToString();
            for (int i = 0; i < primitives.Count; i++)
            {
                if (primitives[i] is DiskPlane)
                    continue;
                if (primitives[i] is Triangle)
                    continue;

                if (primitives[i].name == selectedObject )
                {
                    primitive = primitives[i];
                    break;
                }
            }
            if (primitive is Sphere)
            {
                Sphere tmp = (Sphere)primitive;
                ChoiceSpecular.Value = (decimal)tmp.specular;
                ChoiceReflective.Value = (decimal)tmp.reflective;
                ChoiceColor.BackColor = Color.FromArgb((int)tmp.color.x, (int)tmp.color.y, (int)tmp.color.z);


            }
            else if (primitive is TrianglePyramid)
            {
                TrianglePyramid tmp = (TrianglePyramid)primitive;

                ChoiceSpecular.Value = (decimal)tmp.specular;
                ChoiceReflective.Value = (decimal)tmp.reflective;
                ChoiceColor.BackColor = Color.FromArgb((int)tmp.color.x, (int)tmp.color.y, (int)tmp.color.z);

            }
            else if (primitive is Cylinder)
            {

                Cylinder tmp = (Cylinder)primitive;
                V = tmp.V;
                


                ChoiceSpecular.Value = (decimal)tmp.specular;
                ChoiceReflective.Value = (decimal)tmp.reflective;
                ChoiceColor.BackColor = Color.FromArgb((int)tmp.color.x, (int)tmp.color.y, (int)tmp.color.z);
            }
            else if (primitive is Parallelepiped)
            {
                Parallelepiped tmp = (Parallelepiped)primitive;

                ChoiceSpecular.Value = (decimal)tmp.specular;
                ChoiceReflective.Value = (decimal)tmp.reflective;
                ChoiceColor.BackColor = Color.FromArgb((int)tmp.color.x, (int)tmp.color.y, (int)tmp.color.z);


            }
            else if (primitive is Plane)
            {
                Plane tmp = (Plane)primitive;
                ChoiceSpecular.Value = (decimal)tmp.specular;
                ChoiceReflective.Value = (decimal)tmp.reflective;
                ChoiceColor.BackColor = Color.FromArgb((int)tmp.color.x, (int)tmp.color.y, (int)tmp.color.z);


            }
        }

        private void VisibleLightParametrs(bool isVisible)
        {
            labelLightPos.Visible = isVisible;
            labelChangeLightPos.Visible = isVisible;

            LightPosX.Visible = isVisible;
            ChangeLightPosX.Visible = isVisible;

            LightPosY.Visible = isVisible;
            ChangeLightPosY.Visible = isVisible;

            LightPosZ.Visible = isVisible;
            ChangeLightPosZ.Visible = isVisible;
        }

        private void comboBoxLights_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedLight = this.comboBoxLights.SelectedItem.ToString();
            GetLightCommand getLightCommand = new GetLightCommand(selectedLight);
            facade.executeCommand(getLightCommand);

            Light light = getLightCommand.getResult();

            if (comboBoxLights.SelectedIndex == 0)
            {
                VisibleLightParametrs(false);
                btnDeleteLight.Visible = false;
            }
            else
            {
                VisibleLightParametrs(true);
                if (comboBoxLights.SelectedIndex == 1)
                {
                    btnDeleteLight.Visible = false;
                    labelLightPos.Text = "Направление:";
                    labelChangeLightPos.Text = "Направление:";

                }
                else
                {
                    btnDeleteLight.Visible = true;
                    labelLightPos.Text = "Положение:";
                    labelChangeLightPos.Text = "Положение:";
                }
                LightPosX.Text = light.position.x.ToString();
                LightPosY.Text = light.position.y.ToString();
                LightPosZ.Text = light.position.z.ToString();

                ChangeLightPosX.Value = (decimal)light.position.x;
                ChangeLightPosY.Value = (decimal)light.position.y;
                ChangeLightPosZ.Value = (decimal)light.position.z;

            }
            LightIntensity.Text = light.intensity.ToString();
            ChangeLightIntensity.Value = (decimal)light.intensity;

        }

        private void UpdateLightsName()
        {
            GetLightsNameCommand getLightsNameCommand = new GetLightsNameCommand();
            facade.executeCommand(getLightsNameCommand);
            comboBoxLights.Items.Clear();
            List<string> lightsName = getLightsNameCommand.getResult();
            for (int i = 0; i < lightsName.Count; i++)
                comboBoxLights.Items.Add(lightsName[i]);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "3DConstructor";
            UpdateLightsName();
            comboBoxLights.SelectedIndex = 1;
            tabControl1.SelectedIndex = 1;

            CameraPosX.Text = "0";
            CameraPosY.Text = "0";
            CameraPosZ.Text = "0";
            CameraRotOX.Text = "0";
            CameraRotOY.Text = "0";
            CameraRotOZ.Text = "0";


        }

        private void btnChangeLightParams_Click(object sender, EventArgs e)
        {
            string selectedLight = this.comboBoxLights.SelectedItem.ToString();
            ChangeLightCommand changeLightCommand;
            if (comboBoxLights.SelectedIndex == 0)
            {
                VisibleLightParametrs(false);
                changeLightCommand = new ChangeLightCommand(selectedLight, (double)ChangeLightIntensity.Value);
            }
            else
            {
                changeLightCommand = new ChangeLightCommand(selectedLight,
                   new Vec3d((double)ChangeLightPosX.Value, (double)ChangeLightPosY.Value, (double)ChangeLightPosZ.Value), (double)ChangeLightIntensity.Value);
            }
            facade.executeCommand(changeLightCommand);
            render();
            LightIntensity.Text = ChangeLightIntensity.Value.ToString();
            LightPosX.Text = ChangeLightPosX.Value.ToString();
            LightPosY.Text = ChangeLightPosY.Value.ToString();
            LightPosZ.Text = ChangeLightPosZ.Value.ToString();
        }

        private void btnAddLight_Click(object sender, EventArgs e)
        {
            AddLightCommand addLightCommand = new AddLightCommand(new Vec3d((double)AddLightPosX.Value, (double)AddLightPosY.Value, (double)AddLightPosZ.Value), (double)AddLightIntensity.Value);
            facade.executeCommand(addLightCommand);
            render();
            UpdateLightsName();
            comboBoxLights.SelectedIndex = 1;
        }

        private void btnDeleteLight_Click(object sender, EventArgs e)
        {
            string selectedLight = this.comboBoxLights.SelectedItem.ToString();
            DeleteLightCommand deleteLightCommand = new DeleteLightCommand(selectedLight);
            facade.executeCommand(deleteLightCommand);
            render();
            UpdateLightsName();
            comboBoxLights.SelectedIndex = 1;
        }

        private void ChoiceColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // установка цвета формы
            ChoiceColor.BackColor = colorDialog1.Color;
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (primitive is Plane && primitive.name == "плоскость основания")
            {
                Color color = ChoiceColor.BackColor;
                UpdateBasePlaneCommand updateBasePlaneCommand = new UpdateBasePlaneCommand(new Vec3d((double)color.R, (double)color.G, (double)color.B), (double)ChoiceSpecular.Value, (double)ChoiceReflective.Value);
                facade.executeCommand(updateBasePlaneCommand);
            }
            else
            {
                Color color = ChoiceColor.BackColor;
                UpdatePrimitiveCommand UpdatePrimitiveCommand = new UpdatePrimitiveCommand(
                    primitive.name,
                    new Vec3d((double)color.R, (double)color.G, (double)color.B),
                    (double)ChoiceSpecular.Value,
                    (double)ChoiceReflective.Value);
                facade.executeCommand(UpdatePrimitiveCommand);
            }
            render();
        }



        private void MultiplyMV(double[,] matr)
        {
            double[] tmp = new double[4] { V.x, V.y, V.z, 1 };
            double[] result = new double[4] { 0, 0, 0, 0 };

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    result[i] += tmp[j] * matr[i, j];
                }
            }

            V.x = result[0];
            V.y = result[1];
            V.z = result[2];
        }


        private void btnRender_Click(object sender, EventArgs e)
        {
            render();
        }



        private void labelChoiceSpecular_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void labelLightPos_Click(object sender, EventArgs e)
        {

        }
    }
}
