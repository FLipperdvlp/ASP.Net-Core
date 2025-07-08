using Minecraft_server_API.Classes;

namespace Minecraft_server_API.DataBases;

public class BlockDatabase
{
    private List<Block> blocks = new();

    public void Add(Block block) => blocks.Add(block);

    public bool Exists(int x, int y, int z) => blocks.Any(b => b.X == x && b.Y == y && b.Z == z);

    public Block? GetBlock(int x, int y, int z) => blocks.FirstOrDefault(b => b.X == x && b.Y == y && b.Z == z);
    
    public void Remove(int x, int y, int z)
    {
        var block = blocks.FirstOrDefault(b => b.X == x && b.Y == y && b.Z == z);
        if (block != null)
            blocks.Remove(block);
    }
}
