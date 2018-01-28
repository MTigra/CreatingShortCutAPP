using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shrtcutapp
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// Здесь в args будут парметры которые будут у ярлыка
        ///  </summary>
        [STAThread]
        static void Main(params string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length == 0)
            {
                //вот мы запустим если параметра не было
                //типа мы запустим просто обычную прогу. котрая без параметров
                Application.Run(new Form1());
            }
            else
            {
                // вот мы вызываем нашу фрму с ипользование первого параметра который был у ярлыка.
                //видишь типа вызовем с парметром
                Application.Run(new Form1(args[0]));
            }
           // и вот этот файл обязательно посмотри.
            
        }
    }
}
