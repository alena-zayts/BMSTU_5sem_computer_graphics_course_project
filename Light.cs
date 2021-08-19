namespace Weatherwane
{

    enum LightTypes { Ambient, Point, Directional};
    class Light
    {
        public string name;
        public LightTypes ltype;

        public Vec3 position;
        public double intensity;
        

        public Light(string name, LightTypes ltype, Vec3 position, double intensity)
        {
            this.name = name;
            this.ltype = ltype;

            this.position = position;
            this.intensity = intensity;
        }

        public void update(double intensity, Vec3 position)
        {
            if (this.ltype == LightTypes.Directional)
            {
                this.position = position.Normalize();
            }
            else
            {
                this.position = position;
            }

            this.intensity = intensity;
        }
    }
}
