using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labyrint
{
    public partial class UserControl2 : UserControl
    {
        static int numberOfRows, numberOfColumns;
        static char[,] labyrinthCharacters;


        //Use Singleton Class pattern to create instance. Singleton is the combination of 2 essential properties, so that a class has only one
        //instance and provides a global level of access to it. Often a system only needs to create one instance of a class and
        // that instance will be accessed thorughout the program.
        //So if a system only needs one instance of a class and that instance must be accessible from many parts of the system, one 
        //controls both instantiation and access by making that class singleton
        private static UserControl2 _instance;

        public static UserControl2 Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UserControl2();
                }
                return _instance;
            }
        }

        public UserControl2()
        {
            InitializeComponent();
        }

        static Felt UnvisitedNeighbours(Felt felt)
        {
            int feltRow = felt.row;
            int feltColumn = felt.column;
            Felt newFelt;

            //Hvis man er i kolonnen yderst til venstre:
            if (feltColumn == 0)
            {
                if (labyrinthCharacters[feltRow, feltColumn + 1] == ' ')
                {
                    newFelt = new Felt(feltColumn + 1, feltRow);
                }
                else
                {
                    newFelt = null;
                }
            }
            else
            {

                if (labyrinthCharacters[feltRow - 1, feltColumn] == ' ')
                {
                    newFelt = new Felt(feltColumn, feltRow - 1);
                }
                else if (labyrinthCharacters[feltRow, feltColumn + 1] == ' ')
                {
                    newFelt = new Felt(feltColumn + 1, feltRow);
                }
                else if (labyrinthCharacters[feltRow + 1, feltColumn] == ' ')
                {
                    newFelt = new Felt(feltColumn, feltRow + 1);
                }
                else if (labyrinthCharacters[feltRow, feltColumn - 1] == ' ')
                {
                    newFelt = new Felt(feltColumn - 1, feltRow);
                }
                else
                {

                    newFelt = null;
                }
            }

            return newFelt;
        }

        static bool isExit(Felt felt)
        {

            int feltRow = felt.row;
            int feltColumn = felt.column;

            if (labyrinthCharacters[feltRow, feltColumn + 1] == 'E')
            {
                return true;
            }

            return false;

        }

        private void PaintMe(object sender, PaintEventArgs e) {            

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

                        Stack<Felt> s = new Stack<Felt>();
                        s.Push(new Felt(0, 1));

                        while ((s.Count > 0))
                        {
                            //do rule 1 or 2
                            Felt next = s.Peek();
                            Felt neighbour;
                            if ((neighbour = UnvisitedNeighbours(next)) != null)
                            {
                                if (isExit(neighbour))
                                {
                                    while (s.Count > 1)
                                    {
                                        int rækken = s.Peek().row;
                                        int kolonnen = s.Peek().column;
                                        labyrinthCharacters[rækken, kolonnen] = '*';
                                        s.Pop();
                                    }
                                    labyrinthCharacters[neighbour.row, neighbour.column] = '*';                                    
                                }
                                labyrinthCharacters[neighbour.row, neighbour.column] = '.';
                                s.Push(neighbour);
                            }
                            else
                            {
                                s.Pop();
                                if (s.Count == 1)
                                {
                                    
                                }
                            }
                        }


                        e.Graphics.Clear(Color.AntiqueWhite);
                        Pen p = new Pen(Color.DarkMagenta);

                        Graphics graphicsObj = this.CreateGraphics();
                        Font myFont = new Font("Helvetica", 12, FontStyle.Regular);
                        Font myBoldFont = new Font("Helvetica", 14, FontStyle.Bold);
                        Brush myBrush = new SolidBrush(Color.DarkMagenta);
                        Brush myRedBrush = new SolidBrush(Color.Red);

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
                                else if (labyrinthCharacters[row, col] == '*')
                                {
                                    float x = left + margin + col * xStep + xStep/5;
                                    float y = top + margin + row * yStep + yStep/5;
                                    graphicsObj.DrawString("*", myBoldFont, myRedBrush, x, y);

                                }
                                else if (labyrinthCharacters[row, col] == 'B')
                                {
                                    float x = left + margin +  col * xStep;
                                    float y = top + margin +  row * yStep;
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
