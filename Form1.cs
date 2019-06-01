using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShakalizerWindows
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }
    private ImageCodecInfo GetEncoder(ImageFormat format)
    {

      ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

      foreach (ImageCodecInfo codec in codecs)
      {
        if (codec.FormatID == format.Guid)
        {
          return codec;
        }
      }
      return null;
    }
    private void button1_Click(object sender, EventArgs e)
    {
      // Get a bitmap.
      openFileDialog1.ShowDialog();
      Bitmap bmp1 = new Bitmap(openFileDialog1.FileName);
      ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);

      // Create an Encoder object based on the GUID
      // for the Quality parameter category.
      System.Drawing.Imaging.Encoder myEncoder =
          System.Drawing.Imaging.Encoder.Quality;

      // Create an EncoderParameters object.
      // An EncoderParameters object has an array of EncoderParameter
      // objects. In this case, there is only one
      // EncoderParameter object in the array.
      EncoderParameters myEncoderParameters = new EncoderParameters(1);

      EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 100 - (byte)(numericUpDown1.Value));
      myEncoderParameters.Param[0] = myEncoderParameter;
      saveFileDialog1.ShowDialog();

      bmp1.Save(saveFileDialog1.FileName, jpgEncoder, myEncoderParameters); 

  }
  }
}
