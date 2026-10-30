using Raylib_cs;

namespace vubox.asset;

public static class TextureLoader
{
    private static List<Texture2D> textures = [];

    public static int Load(string path)
    {
        string final = "GameData/" + path;

        if (!File.Exists(final)) return -1;

        textures.Add(Raylib.LoadTexture(final));
        return textures.Count - 1;
    }

    public static void Unload()
    {
        foreach (var tex in textures)
        {
            Raylib.UnloadTexture(tex);
        }
    }

    public static Texture2D GetTexture(int key)
    {
        if (key >= 0 && key < textures.Count) return textures[key];
        throw new Exception($"unable to find texture from key: {key}");
    }

    public static Texture2D? GetTextureUnsure(int key)
    {
        if (key >= 0 && key < textures.Count) return Raylib.IsTextureValid(textures[key]) ? textures[key] : null;
        return null;
    } 

    public static bool Loaded(int key) => key >= 0 && key < textures.Count && Raylib.IsTextureValid(textures[key]);
}