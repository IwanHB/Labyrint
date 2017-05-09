using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Labyrint
{
    public partial class UserControl1 : UserControl
    {
        //Use Singleton Class pattern to create instance. Singleton is the combination of 2 essential properties, so that a class has only one
        //instance and provides a global level of access to it. Often a system only needs to create one instance of a class and
        // that instance will be accessed thorughout the program.
        //So if a system only needs one instance of a class and that instance must be accessible from many parts of the system, one 
        //controls both instantiation and access by making that class singleton
        private static UserControl1 _instance;

        public static UserControl1 Instance {
            get {
                if (_instance == null)
                {
                    _instance = new UserControl1();
                }
                return _instance;
            }
        }


        public UserControl1()
        {
            InitializeComponent();
        }

        private void PaintMe(object sender, PaintEventArgs e)
        {

            int numberOfRows, numberOfColumns;
            char[,] labyrinthCharacters;

            try
            {
                FileStream fs = new FileStream("../../labyrint.txt", FileMode.Open, FileAccess.Read);
                string firstLine = String.Empty;

                using (StreamReader streamReader = new StreamReader(fs, Encoding.UTF8))
                {

                    firstLine = streamReader.ReadLine();

                    //Omdan den første linje på formen 21x21 til et string-array kun med tallene indsat som strings
                    string[] labyrinthDimensions = firstLine.Split('x');

                    //Forsøg på at omdanne de indlæste tal på formen strings i string-arrayet til rigtige heltal
                    if (int.TryParse(labyrinthDimensions[0], out numberOfRows) && int.TryParse(labyrinthDimensions[1], out numberOfColumns))
                    {
                        labyrinthCharacters = new char[numberOfRows, numberOfColumns];

                        string textLine = String.Empty;

                        int i = 0;
                        while ((textLine = streamReader.ReadLine()) != null)
                        {
                            for (int j = 0; j < textLine.Length; j++)
                            {
                                labyrinthCharacters[i, j] = textLine[j];
                            }
                            i++;
                        }
                        e.Graphics.Clear(Color.AntiqueWhite);
                        Pen p = new Pen(Color.DarkMagenta);

                        Graphics graphicsObj = this.CreateGraphics();
                        Font myFont = new Font("Helvetica", 12, FontStyle.Regular);
                        Brush myBrush = new SolidBrush(Color.DarkMagenta);

                        int margin = 9;
                        int width = DisplayRectangle.Width;
                        int height = DisplayRectangle.Height;
                        int top = DisplayRectangle.Top;
                        int left = DisplayRectangle.Left;
                        float xStep = (width - 2 * margin) / numberOfColumns;
                        float yStep = (height - 2 * margin) / numberOfRows;

                        for (int row = 0; row <= numberOfRows; row++)
                        {                         

                            for (int col = 0; col < numberOfColumns; col++)
                            {
                                if (labyrinthCharacters[row, col] == '+')
                                {                                    
                                    float x = left + margin + col * xStep;                                    
                                    float y = top + margin + row * yStep;                                    
                                    e.Graphics.FillRectangle(myBrush, x, y, xStep, yStep);

                                }                                
                                else if (labyrinthCharacters[row, col] == 'B')
                                {
                                    float x = left + margin + col * xStep;
                                    float y = top + margin + row * yStep;
                                    graphicsObj.DrawString("B", myFont, myBrush, x, y);

                                }
                                else if (labyrinthCharacters[row, col] == 'E')
                                {
                                    float x = left + margin + col * xStep;
                                    float y = top + margin + row * yStep;
                                    graphicsObj.DrawString("E", myFont, myBrush, x, y);

                                }                                
                                else
                                {

                                }



                            }

                        }


                    }



                    streamReader.Close();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }



        }
    }
}
