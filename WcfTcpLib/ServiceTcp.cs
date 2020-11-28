using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfTcpLib
{
    public class ServiceTcp : IServiceTcp
    {
        private int count = 0;
        private string path = "D:/";
        private List<string> strings = new List<string>();

        public string GetBase64Encode(string fileName, int offset, int size)
        {
            byte[] piece = File.ReadAllBytes(path + fileName).Skip(offset).Take(size).ToArray();
            return Convert.ToBase64String(piece);
        }


        public string SaveFileBlock(byte[] block)
        {
            string fileName = "newFile" + count.ToString();
            count++;
            FileStream file = File.Create(path + fileName);
            file.Write(block, 0, block.Length);
            file.Close();
            return "Written " + block.Length.ToString() + " bytes to " + fileName;
        }


        private string RemoveSpaces(string txt)
        {
            string text = txt.Replace("  ", " ");

            if (text.Contains("  "))
                return RemoveSpaces(text);
            return text;
        }


        public int GetWordsCount(List<string> text)
        {
            int count = 0;
            foreach (string str in text)
            {
                strings.Add(str);
                if (str != "")
                {
                    string newStr = RemoveSpaces(str).TrimEnd(new char[] { ' ' });
                    string[] words = newStr.Split(new char[] { ' ' });
                    count += words.Length;
                }
            }
            return count;
        }


        public string GetTime()
        {
            return DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss.ffffff K");
        }

    }
}
