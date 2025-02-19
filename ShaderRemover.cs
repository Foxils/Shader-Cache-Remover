namespace Shader_Cache_Remover
{
    class Cleaner
    {
        public static void BeginClean()
        {
            string baseDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            List<List<string>> directories = new List<List<string>> {
                new List<string> { "NVIDIA", "DXCache", "Temp" },
                new List<string> { "NVIDIA", "GLCache" },
                new List<string> { "AMD", "DxCache" },
                new List<string> { "UnrealEngine", "ShaderCache" },
                new List<string> { "LocalLow", "Unity", "Caches" },
                new List<string> { "Temp", "NVIDIA Corporation", "NV_Cache" },
                new List<string> { "Temp", "DXCache" },
                new List<string> { "Temp", "D3DSCache" },
                new List<string> { "Temp", "AMD", "GLCache" },
                new List<string> { "Common", "AMD", "DerivedDataCache" },
                new List<string> { "AMD", "DxcCache" },
                new List<string> { "AMD", "OglCache" },
                new List<string> { "AMD", "VkCache" },
                new List<string> { "AMD", "DX9Cache" },
                new List<string> { "LocalLow", "NVIDIA", "PerDriverVersion", "DXcache" },
                new List<string> { "ov", "cache " },
                new List<string> { "NVIDIA", "OptixCache " },

            };
            try
            {
                foreach (List<string> pathList in directories)
                {
               
                    string fullPath = pathList.Aggregate(baseDirectory, (current, subdir) => Path.Combine(current, subdir));


                    if (Directory.Exists(fullPath))
                    {

                        try
                        {

                            foreach (string file in Directory.GetFiles(fullPath))
                            {
                                try
                                {
                                    File.Delete(file);
                                    Console.WriteLine($"Deleted file: {file}");
                                }
                                catch (IOException)
                                {
                                    
                                    Console.WriteLine($"Could not delete file (Remove Manually) {file} Skipping... ");
                                }
                            }

                            

                        }
                        catch (IOException ex)
                        {
                            Console.WriteLine($"Could not delete contents of {fullPath}: {ex.Message}");
                        }
                    }
                   
                }
                string roamingBaseDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                List<List<string>> roamingDirectories = new List<List<string>> {
                    new List<string> { "Unreal Engine", "Common", "DerivedDataCache" },
                    new List<string> { "Unity", "Asset Store-5.x" },
                    new List<string> { "Microsoft", "CLR_v4.0" }
                };

                foreach (List<string> pathList in roamingDirectories)
                {
                    string fullPath = pathList.Aggregate(roamingBaseDirectory, (current, subdir) => Path.Combine(current, subdir));
                  
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Unable to remove files - did you run as administrator? {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}