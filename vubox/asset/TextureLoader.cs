using Raylib_cs;

namespace vubox.asset;

public static class TextureLoader
{
    private static Dictionary<string, Texture2D> textures = [];

    public static void LoadFrom(string directory)
    {
        if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

        foreach (string file in Directory.EnumerateFiles(directory))
        {
            if (!File.Exists(file)) continue; // if its not file

            Texture2D texture = Raylib.LoadTexture(file);
            Raylib.SetTextureFilter(texture, TextureFilter.Point);
            string name = file.Split("/").Last().Split(".").First();
            textures[name] = texture;
        }
    }

    public static void Unload()
    {
        foreach (var pair in textures)
        {
            Raylib.UnloadTexture(pair.Value);
        }
    }

    public static Texture2D GetTexture(string key)
    {
        if (textures.TryGetValue(key, out var t)) return t;
        throw new Exception($"unable to find texture: {key}");
    }

    public static Texture2D? GetTextureUnsure(string key)
    {
        if (textures.TryGetValue(key, out var t)) return t;
        return null;
    }

    public static bool Loaded(string key) => textures.TryGetValue(key, out var t) ? Raylib.IsTextureValid(t) : false;
}