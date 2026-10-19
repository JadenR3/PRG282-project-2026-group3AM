using System;
using System.IO;
using System.Windows.Forms;

namespace Baobab_Ridge_Wildlife_Rehabilitation_Records_System
{
    public static class FileManager
    {
        public static string ReadFileSafe(string path)
        {
            string fileContent = string.Empty;

            try
            {
                // check for file presence
                if (File.Exists(path) == false)
                {
                    MessageBox.Show("The specified file could not be found.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return fileContent;
                }

                fileContent = File.ReadAllText(path);
            }
            // PLZ always input specific file directory before IOException
            catch (FileNotFoundException)
            {
                MessageBox.Show("The file was not found. Please check the file path.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("The directory path could not be found.", "Directory Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException)
            {
                MessageBox.Show("The file is currently in use by another process. Please close it and try again.", "File In Use", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Access denied. Check if the file is read-only or if you lack permissions.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return fileContent;
        }

        public static void WriteFileSafe(string path, string content)
        {
            try
            {
                File.WriteAllText(path, content);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("The file path was not found.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("The directory path was not found.", "Directory Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException)
            {
                MessageBox.Show("The file is currently locked or in use by another application.", "File In Use", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Access denied. The file may be read-only.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
