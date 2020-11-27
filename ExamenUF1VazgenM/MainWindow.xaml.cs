using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExamenUF1VazgenM
{
    
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }
       
      
        private void btnGenerar_Click(object sender, RoutedEventArgs e)
        {
            const int width = 400;
            const int height = 400;

            var imatge = GenerarImatge(width, height);

            imageFoto.Source = imatge;
        }
      
        #region Metodos de Estenografiar Pare A

        /// <summary>
        /// Genera imatge de 32 bits amb forma vertical
        /// </summary>
        /// <returns> retorna en format WriteableBitmap</returns>
        public WriteableBitmap GenerarImatge(int width, int height)
        {
           
            WriteableBitmap wBr = null;
            byte[,,] pixels = new byte[height, width, 4];
            int stride = 4 * width;
            Int32Rect rect = new Int32Rect(0, 0, width, height);
            try
            {
                wBr = new WriteableBitmap(width, height, 100, 100, PixelFormats.Bgr32, null);

                //dibuixem el background de imatge COLOR
                for (int row = 0; row < height; row++)
                {
                    for (int col = 0; col < width; col++)
                    {
                        pixels[row, col, 2] = 0;
                    }
                }




                //manipulacio de bits perque suriti de forma vertical
                for (int row = 0; row < height; row++)
                {

                    for (int col = 0; col < height; col++)
                    {
                     if(col%50>0)   pixels[row, col, 0] = 250;//com que dibuixem verticalment modifiquem els cols 
                    } 

                }

                byte[] pixels1d = new byte[height * width * 4];
                int index = 0;
                for (int row = 0; row < height; row++)
                {
                    for (int col = 0; col < width; col++)
                    {
                        for (int i = 0; i < 4; i++)
                            pixels1d[index++] = pixels[row, col, i];
                    }
                }
                wBr.WritePixels(rect, pixels1d, stride, 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);//imprimim per debug
            }
            return wBr;
        }
        #endregion
       
        #region Parte B:Metodo que estenografia sobre el metodo WriteTable
       /// <summary>
       /// Metodo que estenografia en imatge 
       /// </summary>
        public void EstenograImatge()
        {
           const int ultimNumDNI = 7;
           const int llocEstenografiat = ultimNumDNI % 10 + 1;
           const int width = 400;
           const int height = 400;
            var imatge = GenerarImatge(width,height);


        }
        #endregion
    }
}
