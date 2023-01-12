using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityManager
{
    public class Formatter
    {
        /// <summary>
        /// Returns username based on the Windows Logon Name. 
        /// </summary>
        /// <param name="winLogonName"> Windows logon name can be formatted either as a UPN (<username>@<domain_name>) or a SPN (<domain_name>\<username>) </param>
        /// <returns> username </returns>
        public static string ParseName(string winLogonName)
        {
            string[] parts = new string[] { };

            if (winLogonName.Contains("@"))
            {
                ///UPN format
                parts = winLogonName.Split('@');
                return parts[0];
            }
            else if (winLogonName.Contains("\\"))
            {
                /// SPN format
                parts = winLogonName.Split('\\');
                return parts[1];
            }
            else
            {
                return winLogonName;
            }
        }

		const int headerLenght = 54;

		/// <summary>
		/// Splits image bytes to the header and body
		/// </summary>
		public static void Decompose(byte[] bytePicture, out byte[] header, out byte[] body)
		{
			header = new byte[headerLenght];
			body = new byte[bytePicture.Length - headerLenght];

			for (int i = 0; i < bytePicture.Length; i++)
			{
				if (i < headerLenght)
				{
					header[i] = bytePicture[i];
				}
				else
				{
					body[i - headerLenght] = bytePicture[i];
				}
			}
		}

		/// <summary>
		///  Links the image header and body together into one array
		/// </summary>
		public static void Compose(byte[] header, byte[] body, int outputLenght, string outFile)
		{
			byte[] output = new byte[outputLenght];

			for (int i = 0; i < outputLenght; i++)
			{
				if (i < headerLenght)
				{
					output[i] = header[i];
				}
				else
				{
					output[i] = body[i - headerLenght];
				}
			}

			BinaryWriter Writer = new BinaryWriter(File.OpenWrite(outFile));
			Writer.Write(output);       // Writer raw data    
			Writer.Flush();
			Writer.Close();
		}
	}
}
