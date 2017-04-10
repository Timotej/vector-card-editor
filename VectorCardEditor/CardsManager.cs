using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;

namespace VectorCardEditor
{
    [Serializable]
    class CardsManager
    {
        public List<Card> CardsList { get; private set; } = new List<Card>();
        public List<Card> SelectedCardsList { get; private set; } = new List<Card>();

        public CardsManager()
        {

        }

        public void DrawAllCards(Graphics g)
        {
            foreach (var card in CardsList)
            {
                card.DrawCard(g);
            }
        }

        public void SaveAsSVG()
        {
            FolderBrowserDialog saveFileDialog1 = new FolderBrowserDialog();

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog1.SelectedPath != "")
                {
                    Directory.CreateDirectory(saveFileDialog1.SelectedPath);
                    var fileName = Path.GetFileName(saveFileDialog1.SelectedPath);
                    for (int i = 0; i < CardsList.Count; i++)
                    {
                        CardsList[i].SaveCard(saveFileDialog1.SelectedPath + "\\" + fileName + (i + 1) + ".svg");
                    }
                }
            }
        }

        public void SaveAsPNG()
        {
            FolderBrowserDialog saveFileDialog1 = new FolderBrowserDialog();

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog1.SelectedPath != "")
                {
                    Directory.CreateDirectory(saveFileDialog1.SelectedPath);
                    var fileName = Path.GetFileName(saveFileDialog1.SelectedPath);
                    for (int i = 0; i < CardsList.Count; i++)
                    {
                        CardsList[i].SaveAsPng(saveFileDialog1.SelectedPath + "\\" + fileName + (i + 1) + ".png");
                    }
                }
            }
        }

        public void SaveAsSingleFile()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "vce files (*.vce)|*.vce";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog1.FileName != "")
                {
                    IFormatter formatter = new BinaryFormatter();
                    Stream stream = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write, FileShare.None);
                    formatter.Serialize(stream, this);
                    stream.Close();
                }
            }
        }

        public void OpenSingleFile()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "vce files (*.vce)|*.vce";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog1.FileName != "")
                {
                    FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open);
                    try
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        var newInstance = (CardsManager)formatter.Deserialize(fs);
                        CardsList.Clear();
                        CardsList = null;
                        CardsList = newInstance.CardsList;

                        SelectedCardsList.Clear();
                        SelectedCardsList = null;
                        SelectedCardsList = newInstance.SelectedCardsList;
                    }
                    catch (SerializationException e)
                    {
                        Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                        throw;
                    }
                    finally
                    {
                        fs.Close();
                    }
                }
            }
        }

        public void SaveAsSingleSVG()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "svg files (*.svg)|*.svg";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog1.FileName != "")
                {
                    var doc = new XmlDocument();
                    var declaration = doc.CreateXmlDeclaration("1.0", "UTF-8", "no");
                    doc.AppendChild(declaration);

                    var svgNode = doc.CreateElement("svg");
                    svgNode.SetAttribute("width", "100");
                    svgNode.SetAttribute("height", "100");
                    doc.AppendChild(svgNode);

                    foreach (var item in CardsList)
                    {
                        item.SaveIntoSingleSVG(doc);
                    }

                    doc.Save(saveFileDialog1.FileName);
                }
            }
        }

        public void DeleteSelectedCards()
        {
            foreach (var card in SelectedCardsList)
            {
                CardsList.Remove(card);
            }
            SelectedCardsList.Clear();
        }

        public void DeleteAllCards()
        {
            SelectedCardsList.Clear();
            CardsList.Clear();
        }

        public void DeselectAllCards()
        {
            foreach (var card in SelectedCardsList)
            {
                card.Selected = false;
            }
            SelectedCardsList.Clear();
        }

        public void MoveAllSelectedCardsByVector(Point vector)
        {
            foreach (var item in SelectedCardsList)
            {
                item.MoveByVector(vector);
            }
        }

        public void ResizeAll(double width, double height)
        {
            foreach (var item in CardsList)
            {
                item.Resize(width, height);
            }
        }

        public bool IsInBottomRightCorner(Point p)
        {
            foreach (var item in CardsList)
            {
                if (item.IsInBottomRightCorner(p))
                {
                    return true;
                }
            }
            return false;
        }

        public void ColumnAlign()
        {
            if (CardsList.Count > 1)
            {
                for (int i = 1; i < CardsList.Count; i++)
                {
                    CardsList[i].OriginPoint = new Point(CardsList[0].OriginPoint.X, CardsList[0].OriginPoint.Y + ((CardsList[i].RealHeight + 5) * i));
                }
            }
        }

        public void RowAlign()
        {
            if (CardsList.Count > 1)
            {
                for (int i = 1; i < CardsList.Count; i++)
                {
                    CardsList[i].OriginPoint = new Point(CardsList[0].OriginPoint.X + ((CardsList[i].RealWidth + 5) * i), CardsList[0].OriginPoint.Y);
                }
            }
        }

        public Tuple<string, string> GenerateCardsCoordinates()
        {
            string xCoords = "x = [";
            string yCoords = "y = [";
            for (int i = 0; i < CardsList.Count; i++)
            {
                xCoords += CardsList[i].OriginPoint.X;
                yCoords += CardsList[i].OriginPoint.Y - Form1.HEIGHT_DIFF;

                xCoords = i < CardsList.Count - 1 ? xCoords + "," : xCoords;
                yCoords = i < CardsList.Count - 1 ? yCoords + "," : yCoords;
            }
            xCoords += "]";
            yCoords += "]";

            return new Tuple<string, string>(xCoords, yCoords);
        }

        public void SaveCoordinatesToFile()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog1.FileName != "")
                {
                    using (StreamWriter sw = File.CreateText(saveFileDialog1.FileName))
                    {
                        var coords = GenerateCardsCoordinates();
                        sw.WriteLine(coords.Item1);
                        sw.WriteLine(coords.Item2);
                    }
                }
            }
        }
    }
}
