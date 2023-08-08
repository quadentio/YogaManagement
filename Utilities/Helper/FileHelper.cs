using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Helper
{
    public static class FileHelper
    {
        ///
        /// FILE MANIPULATION
        /// 1. File.Create()
        /// Example: File.Create("path/to/file.txt");
        /// 2. File.WriteAllText()
        /// Example: File.WriteAllText("path/to/file.txt", "Hello, World!");
        /// 3. File.ReadAllText()
        /// Example: string content = File.ReadAllText("path/to/file.txt");
        /// 4. File.ReadAllLine()
        /// Example: string[] content = File.ReadAllLine("path/to/file.txt");
        /// 5. File.AppendAllText()
        /// Example: File.AppendAllText("path/to/file.txt", "New content");
        /// 6. File.Delete()
        /// Example: File.Delete("path/to/file.txt");
        /// 7. File.Exists()
        /// Example: File.Exist("path/to/file.txt");
        /// 8. File.Move()
        /// Example: File.Move("path/to/file.txt");
        /// 9. File.Copy()
        /// Example: File.Copy("path/to/source.txt", "path/to/destination.txt");
        /// 

        ///
        /// DIRECTORY MANIPULATION
        /// 1. Directory.CreateDirectory()
        /// Example: Directory.CreateDirectory("path/to/directory");
        /// 2. Directory.Delete()
        /// Example: Directory.Delete("path/to/directory");
        /// 3. Directory.Exists()
        /// Example: bool exists = Directory.Exists("path/to/directory");
        /// 4. Directory.Move()
        /// Example: Directory.Move("old/path/directory", "new/path/directory");
        /// 5. Directory.Copy()
        /// Example: Directory.Copy("source/path/directory", "destination/path/directory");
        /// 6. Directory.GetFiles()
        /// Example: string[] files = Directory.GetFiles("path/to/directory");
        /// 7. Directory.GetDirectories()
        /// Example: string[] directories = Directory.GetDirectories("path/to/directory");
        /// 8. Directory.EnumerateFiles() (lazily enumerable file)
        /// Example: IEnumerable<string> files = Directory.EnumerateFiles("path/to/directory");
        /// 9. Directory.EnumerateDirectories()
        /// Example: IEnumerable<string> files = Directory.EnumerateDirectories("path/to/directory");
        /// 

        ///
        /// PATH MANIPULATION
        /// 1. Path.Combine()
        /// Example: string combinedPath = Path.Combine("path1", "path2", "file.txt");
        /// 2. Path.GetFileName()
        /// Example: 
        /// 3. Path.GetExtension() [Get extension of file]
        /// Example: string extension = Path.GetExtension("path/to/file");
        /// 4. Path.GetDirectoryName()
        /// Example: string directoryName = Path.GetDirectoryName("path/to/file.txt");
        /// 5. Path.GetPathRoot()
        /// Example: string rootDirectory = Path.GetPathRoot("C:/path/to/file.txt");
        /// 6. Path.IsPathRooted()
        /// Example: 
        /// 7. Path.IsPathFullyQualified() method to check if a path is fully qualified.
        /// Example:
        /// 8. Path.GetFullPath()
        /// Example:
    }
}
