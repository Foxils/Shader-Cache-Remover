using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Shader_Cache_Remover
{
    class Cleaner
    {
        public static void BeginClean()
        {
            string baseDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string roamingBaseDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            // Local cache 
            List<List<string>> directories = new List<List<string>>
            {
                new List<string> { "NVIDIA", "DXCache" },
                new List<string> { "NVIDIA", "GLCache" },
                new List<string> { "NVIDIA Corporation", "NV_Cache" },
                new List<string> { "NVIDIA", "OptixCache" },
                new List<string> { "AMD", "DxCache" },
                new List<string> { "AMD", "GLCache" },
                new List<string> { "AMD", "VkCache" },
                new List<string> { "AMD", "OglCache" },
                new List<string> { "AMD", "DxcCache" },
                new List<string> { "UnrealEngine", "ShaderCache" },
                new List<string> { "LocalLow", "Unity", "Caches" },
                new List<string> { "Temp", "DXCache" },
                new List<string> { "Temp", "D3DSCache" },
                new List<string> { "Temp", "NVIDIA Corporation", "NV_Cache" },
                new List<string> { "ov", "cache" }
            };

            // Roaming cache 
            List<List<string>> roamingDirectories = new List<List<string>>
            {
                new List<string> { "Unreal Engine", "Common", "DerivedDataCache" },
                new List<string> { "Unity", "Asset Store-5.x" },
                new List<string> { "Microsoft", "CLR_v4.0" }
            };

            try
            {
                //  local directories
                foreach (List<string> pathList in directories)
                {
                    string fullPath = pathList.Aggregate(baseDirectory, Path.Combine);

                    if (Directory.Exists(fullPath))
                    {
                        DeleteFilesInDirectory(fullPath);
                    }
                }

                // roaming directories
                foreach (List<string> pathList in roamingDirectories)
                {
                    string fullPath = pathList.Aggregate(roamingBaseDirectory, Path.Combine);

                    if (Directory.Exists(fullPath))
                    {
                        DeleteFilesInDirectory(fullPath);
                    }
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Access denied (run as Administrator?): {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }

        private static void DeleteFilesInDirectory(string directoryPath)
        {
            try
            {
                string[] files = Directory.GetFiles(directoryPath);

                foreach (string file in files)
                {
                    try
                    {
                        File.Delete(file);
                        Console.WriteLine($"Deleted file: {file}");
                    }
                    catch (IOException)
                    {
                        Console.WriteLine($"Could not delete file (in use or protected): {file}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to process directory: {directoryPath}. Error: {ex.Message}");
            }
        }
    }
}
