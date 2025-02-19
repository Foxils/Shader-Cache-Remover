## Shader Cache Remover

This C# script is designed to remove shader cache files from common cache directories. Over time, shader caches can impact system performance. When these caches are deleted, they will be automatically rebuilt as needed.


Modern graphics card software, such as AMD Adrenalin, typically includes an option to clear the shader cache. However, this script ensures that any leftover and specific game engine shader files.

It targets files that may remain after using the driver software, as well as shader caches related to game engines, ensuring a more thorough cleanup.
##
While all systems store shader cache files, some are specific to certain technologies, such as AMD, NVIDIA, or game engines like Unreal and Unity. If a particular cache file cannot be found, an error may occur – this is normal and simply means that the file is not present on your system.

Please note that cache locations may change occasionally with driver updates. As a result, the script may temporarily stop working after such updates. It will be updated accordingly, but you may need to wait for the new version in case of changes.

#
Cache locations checked:

+ NVIDIA DXCache
+ NVIDIA GLCache
+ NVIDIA OptixCache
+ NVIDIA Nv_Cache
+ Unity Cache
+ Unreal ShaderCache
+ AMD DerivedDataCache
+ AMD OglCache
+ AMD VkCache 
+ AMD DX9Cache
+ AMD DxCache
+ D3DSCache
