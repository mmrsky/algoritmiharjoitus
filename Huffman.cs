using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algoritmi
{
    // Muodostetaan tekstistä huffman koodattu systeemi

    class HuffmanNode : IEquatable<HuffmanNode>, IComparable<HuffmanNode>
    {
        public int Frequency { get; set; }
        public char C { get; set; }
        public string code { get; set; }
        public HuffmanNode left;
        public HuffmanNode right;


        public HuffmanNode(char c)
        {
            this.C = c;
            this.Frequency = 1;
        }

        public HuffmanNode(HuffmanNode first, HuffmanNode second)
        {
            this.Frequency = first.Frequency + second.Frequency;
            left = first;
            right = second;
        }

        public override string ToString()
        {
            return "Character: " + this.C + "\tFrequency: " + this.Frequency + "\tCode: " + this.code;
        }
        public bool Equals(HuffmanNode other)
        {
            if (this.C == other.C)
            {
                this.Frequency += 1;
                return true;
            }
            else
            {
                return false;
            }
        }

        int IComparable<HuffmanNode>.CompareTo(HuffmanNode other)
        {
            return this.Frequency.CompareTo(other.Frequency);
        }
    }

    class Huffmann
    {
        public List<HuffmanNode> nodes = new List<HuffmanNode>();
        public List<HuffmanNode> codelist = new List<HuffmanNode>();
        public void CreateMinHeap(string text)
        {
            foreach (var character in text)
            {
                if (nodes.Contains(new HuffmanNode(character)))
                {
                    // node on jo olemassa
                }
                else
                {
                    nodes.Add(new HuffmanNode(character));
                }
           
            }
            nodes.Sort();

            HuffmanNode root = null; //new HuffmanNode(null,null);

            while (nodes.Count > 1)
            {
                HuffmanNode smallestFreq = nodes[0];
                HuffmanNode secondSmallestFreq = nodes[1];

                HuffmanNode combined = new HuffmanNode(smallestFreq, secondSmallestFreq);
                nodes.RemoveAt(1);
                nodes.RemoveAt(0);

                root = combined;
                nodes.Add(combined);
                nodes.Sort();
            }
            CreateCode(root,"");
        }

        public void CreateCode(HuffmanNode node, string s)
        {
            if (node.left == null && node.right == null && Char.IsLetter(node.C))
            {
                node.code = s;
                codelist.Add(node);
                //MessageBox.Show(node.ToString());
                return;
            }

            CreateCode(node.left, s + "0");
            CreateCode(node.right, s + "1");
        }


    }
}

//