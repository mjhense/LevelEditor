using System;

namespace LevelEditor
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(String[] args)
        {
            Form1 frm = new Form1();
            frm.Show();
            frm.game = new Game1(frm.pnlSurface.Handle, ref frm, frm.pnlSurface);
            frm.game.Run();
        }
    }
#endif
}