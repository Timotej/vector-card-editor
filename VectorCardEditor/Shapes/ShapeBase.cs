using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Drawing;
namespace VectorCardEditor
{
    public abstract class ShapeBase
    {
        public ShapeBase() { }

        public abstract void Load(XmlNode node);
        public abstract void Save(XmlDocument doc);
        public abstract void Draw(Graphics g);
    }
}
