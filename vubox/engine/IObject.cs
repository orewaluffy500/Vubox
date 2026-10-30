namespace vubox.engine;

public interface IObject
{
    void Load();
    void Unload();
    void Draw();
    void Update(float dt);
}