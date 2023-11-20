using StereoKit;


namespace SK_Helpers
{
    internal class Ruler
    {
        private static Pose demoRuler = new(0, 0, 0.5f, Quat.Identity);


        private static void RulerWindow()
        {
            UI.HandleBegin("Ruler", ref demoRuler, new Bounds(new Vec3(31, 4, 1) * U.cm), true);
            Color32 color = Color.HSV(0.6f, 0.5f, 1);
            Text.Add("Centimeters", Matrix.TRS(new Vec3(14.5f, -1.5f, -0.6f) * U.cm, Quat.Identity, 0.3f), TextAlign.XLeft | TextAlign.YBottom);

            for (var d = 0; d <= 60; d += 1)
            {
                var x = d / 2.0f;
                var size = d % 2 == 0 ? 1f : 0.15f;
                Lines.Add(new Vec3(15 - x, 1.8f, -0.6f) * U.cm, new Vec3(15 - x, 1.8f - size, -0.6f) * U.cm, color, U.mm * 0.5f);

                if (d % 2 == 0 && d / 2 != 30)
                {
                    Text.Add((d / 2).ToString(), Matrix.TRS(new Vec3(15 - x - 0.1f, 2 - size, -0.6f) * U.cm, Quat.Identity, 0.2f), TextAlign.XLeft | TextAlign.YBottom);
                }

                UI.HandleEnd();
            }
        }
    }
}