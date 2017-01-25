using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

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

        public void DeleteSelectedCards()
        {
            foreach (var card in SelectedCardsList)
            {
                CardsList.Remove(card);
            }
            SelectedCardsList.Clear();
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

        public void StopEditingAll()
        {
            foreach (var item in CardsList)
            {
                item.StopEdit();
            }
        }
    }
}
