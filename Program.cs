using StereoKit;


namespace SK_Helpers
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Initialize StereoKit
            var settings = new SKSettings
            {
                appName = "SK_Helpers",
                assetsFolder = "Assets"
            };

            if (!SK.Initialize(settings))
            {
                return;
            }


            // Create assets used by the app
            var cubePose = new Pose(0, 0, -0.5f);

            var cube = Model.FromMesh(
                Mesh.GenerateRoundedCube(Vec3.One * 0.1f, 0.02f),
                Material.UI);

            var floorTransform = Matrix.TS(0, -1.5f, 0, new Vec3(30, 0.1f, 30));
            var floorMaterial = new Material("floor.hlsl");
            floorMaterial.Transparency = Transparency.Blend;


            // Core application loop
            SK.Run(() =>
            {
                if (SK.System.displayType == Display.Opaque)
                {
                    Mesh.Cube.Draw(floorMaterial, floorTransform);
                }

                UI.Handle("Cube", ref cubePose, cube.Bounds);
                cube.Draw(cubePose.ToMatrix());
            });
        }
    }
}