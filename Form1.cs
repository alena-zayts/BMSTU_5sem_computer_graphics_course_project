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
        bool smthChanged;
        
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

            this.smthChanged = true;
            render();

        }

        void render()
        {
            int numThreads = (int)this.numericNumThreads.Value;
            Command renderCommand = new RenderCommand(ref canvas, checkBoxNebo.Checked, numThreads, ref this.textBoxTime);
            
            facade.executeCommand(renderCommand);
        }

        void dynamicButton_Click(object sender, EventArgs e)
        {
            bool reverse = this.radioRight.Checked;
            bool drawNebo = checkBoxNebo.Checked;
            int speed = this.trackBarSpeed.Maximum - this.trackBarSpeed.Value + 1;
            int numThreads = (int) this.numericNumThreads.Value;
            bool createArray = this.smthChanged;
            int n = this.trackBarN.Value;

            Command dynamicRenderCommand = new DynamicRenderCommand(ref canvas, drawNebo, ref this.progressBar, reverse, speed, numThreads, ref this.textBoxTime, createArray, n);
            facade.executeCommand(dynamicRenderCommand);

            this.smthChanged = false;
            ableDynamicParametrs(false);
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
                MessageBox.Show("Ошибка загрузки.");
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



        private void initTabControl1()
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
            choiceObject.SelectedIndex = 0;
            
            string selectedObject = this.choiceObject.SelectedItem.ToString();
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

            this.smthChanged = true;
            render();
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

            this.smthChanged = true;
            render();
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

            this.smthChanged = true;
            render();

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

            this.smthChanged = true;
            render();

        }

private void choiceObject_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedObject = this.choiceObject.SelectedItem.ToString();
            string info = "";
            for (int i = 0; i < primitives.Count; i++)
            {
                if ((primitives[i] is DiskPlane) || (primitives[i] is Triangle))
                    continue;

                if (primitives[i].name == selectedObject )
                {
                    primitive = primitives[i];
                    break;
                }
            }
            Material material_tmp = primitive.material;
            ChoiceSpecular.Value = (decimal)material_tmp.specular;
            ChoiceReflective.Value = (decimal)material_tmp.reflective;
            ChoiceColor.BackColor = Color.FromArgb((int)material_tmp.color.x, (int)material_tmp.color.y, (int)material_tmp.color.z);
            if (primitive is Sphere)
            {
                Sphere tmp = (Sphere)primitive;

                info = "Тип: Сфера, ";
                info += "Вращается: " + tmp.moving + ", ";
                info += "Центр (" + tmp.C.x + "; " + tmp.C.y + "; " + tmp.C.z + "), ";
                info += "Радиус: = " + tmp.radius;

            }
            else if (primitive is TrianglePyramid)
            {
                TrianglePyramid tmp = (TrianglePyramid)primitive;

                info = "Тип: Пирамида, ";
                info += "Вращается: " + tmp.moving + ", ";
                info += "P = (" + tmp.P.x + "; " + tmp.P.y + "; " + tmp.P.z + "), ";
                info += "A = (" + tmp.A.x + "; " + tmp.A.y + "; " + tmp.A.z + "), ";
                info += "B = (" + tmp.B.x + "; " + tmp.B.y + "; " + tmp.B.z + "), ";
                info += "C = (" + tmp.C.x + "; " + tmp.C.y + "; " + tmp.C.z + ")";

            }
            else if (primitive is Cylinder)
            {
                Cylinder tmp = (Cylinder)primitive;

                info = "Тип: Цилиндр, ";
                info += "Вращается: " + tmp.moving + ", ";
                info += "Центр основания = (" + tmp.C.x + "; " + tmp.C.y + "; " + tmp.C.z + "), ";
                info += "Радиус = " + tmp.radius + ", ";
                info += "Вектор оси = (" + String.Format("{0:f6}", tmp.V.x) + "; " + String.Format("{0:f6}", tmp.V.y) + "; " + String.Format("{0:f6}", tmp.V.z) + "), ";
                info += "Высота = " + tmp.maxm;
            }
            else if (primitive is Parallelepiped)
            {
                Parallelepiped tmp = (Parallelepiped)primitive;

                info = "Тип: Параллелепипед, ";
                info += "Вращается: " + tmp.moving + ", ";
                info += "'минимальная' вершина = (" + tmp.C.x + "; " + tmp.C.y + "; " + tmp.C.z + "), ";
                info += "'максимальная' вершина  = (" + tmp.E.x + "; " + tmp.E.y + "; " + tmp.E.z + ")";

            }
            else if (primitive is Plane)
            {
                Plane tmp = (Plane)primitive;

                info = "Вращается: " + tmp.moving;
            }
            listBox2.Items.Clear();
            listBox2.Items.Add(info);
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

            label2.Visible = isVisible;
            label3.Visible = isVisible;
            label4.Visible = isVisible;
            label5.Visible = isVisible;
            label6.Visible = isVisible;
            label7.Visible = isVisible;
        }

        private void ableDynamicParametrs(bool isAble)
        {
            trackBarN.Enabled = isAble;
            checkBoxNebo.Enabled = isAble;
            numericNumThreads.Enabled = isAble;
            dynamicButton.Enabled = isAble;

            btnChange.Enabled = isAble;

            btnDeleteLight.Enabled = isAble;
            btnAddLight.Enabled = isAble;
            btnChangeLightParams.Enabled = isAble;

            buttonRollCamera.Enabled = isAble;
            buttonPitchCamera.Enabled = isAble;
            buttonYawCamera.Enabled = isAble;
            buttonMoveCamera.Enabled = isAble;
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
                    labelLightPos.Text = "Позиция:";
                    labelChangeLightPos.Text = "Позиция:";
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
            this.Text = "Weatherwane";
            UpdateLightsName();
            initTabControl1();
            comboBoxLights.SelectedIndex = 1;
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
            this.smthChanged = true;
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

            this.smthChanged = true;
            render();

            UpdateLightsName();
            comboBoxLights.SelectedIndex = 1;
        }

        private void btnDeleteLight_Click(object sender, EventArgs e)
        {
            string selectedLight = this.comboBoxLights.SelectedItem.ToString();
            DeleteLightCommand deleteLightCommand = new DeleteLightCommand(selectedLight);
            facade.executeCommand(deleteLightCommand);
            this.smthChanged = true;
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
            Color color = ChoiceColor.BackColor;
            UpdatePrimitiveCommand UpdatePrimitiveCommand = new UpdatePrimitiveCommand(
                primitive.name,
                new Vec3d((double)color.R, (double)color.G, (double)color.B),
                (double)ChoiceSpecular.Value,
                (double)ChoiceReflective.Value);
            facade.executeCommand(UpdatePrimitiveCommand);

            this.smthChanged = true;
            render();
        }

        private void radioRight_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioRight.Checked)
            {
                this.radioLeft.Checked = false;

                bool reverse = this.radioRight.Checked;
                int speed = this.trackBarSpeed.Maximum - this.trackBarSpeed.Value + 1;

                ChangeParamsCommand ChangeParamsCommand = new ChangeParamsCommand(reverse, speed);
                facade.executeCommand(ChangeParamsCommand);
            }
        }

        private void radioLeft_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioLeft.Checked)
            {
                this.radioRight.Checked = false;

                bool reverse = this.radioRight.Checked;
                int speed = this.trackBarSpeed.Maximum - this.trackBarSpeed.Value + 1;

                ChangeParamsCommand ChangeParamsCommand = new ChangeParamsCommand(reverse, speed);
                facade.executeCommand(ChangeParamsCommand);
            }
        }

        private void offButton_Click(object sender, EventArgs e)
        {
            StopRenderCommand StopRenderCommand = new StopRenderCommand();
            facade.executeCommand(StopRenderCommand);
            ableDynamicParametrs(true);
        }

        private void trackBarSpeed_Scroll(object sender, EventArgs e)
        {
            bool reverse = this.radioRight.Checked;
            int speed = this.trackBarSpeed.Maximum - this.trackBarSpeed.Value + 1;

            ChangeParamsCommand ChangeParamsCommand = new ChangeParamsCommand(reverse, speed);
            facade.executeCommand(ChangeParamsCommand);
        }

        private void checkBoxNebo_CheckedChanged(object sender, EventArgs e)
        {
            smthChanged = true;
        }

        private void trackBarN_Scroll(object sender, EventArgs e)
        {
            smthChanged = true;
        }
    }
}
