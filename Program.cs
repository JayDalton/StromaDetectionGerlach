using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using Glaukopis.SlideProcessing;
using SharpAccessory.Imaging.DigitalPathology;
using SharpAccessory.Imaging.Processors;
using SharpAccessory.Imaging.Segmentation;
//using SharpAccessory.VirtualMicroscopy;

namespace StromaDetection
{
  class Program
  {
    private static List<Eingabe> items;

    static void Main(string[] args)
    {
      if (checkParams(args))
      {
        readInputFile(args[0]);
        var prozessingHelper = new Processing(items[0].FileName);
        //var slide = prozessingHelper.Slide;
      }
      else
      {
        Console.WriteLine("Eine Alternative Eingabe wählen:");
        Console.WriteLine("StromaDetection.exe <eingabe.csv> <ausgabe.csv>");
        Console.WriteLine("StromaDetection.exe <eingabe.png> <ausgabe.csv>");
      }
    }

    private static void readInputFile(string fileName)
    {
      string line;
      items = new List<Eingabe>();
      StreamReader file = new StreamReader(fileName);
      while ((line = file.ReadLine()) != null)
      {
        Console.WriteLine(line);
        items.Add(parseLine(line));
      }
      file.Close();
    }

    private static Eingabe parseLine(string line)
    {
      string[] part = line.Split(new char[] { ';' });
      return new Eingabe
      {
        Identify = uint.Parse(part[0]),
        FileName = part[1],
        UpperLeft = new Point(double.Parse(part[2]), double.Parse(part[3])),
        LowerRight = new Point(double.Parse(part[4]), double.Parse(part[5]))
      };
    }

    private static bool checkParams(string[] parms)
    {
      bool result = false;
      if (parms.Length == 2 && File.Exists(parms[0]))
      {
        result = true;
      }
      return result;
    }

    private bool readInput(string fileName)
    {
      return true;
    }
  }
}
