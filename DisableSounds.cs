using CounterStrikeSharp.API.Core;

namespace CS2_DisableSounds
{
    public class DisableSounds : BasePlugin
	{
		public override string ModuleName => "Disable Sounds";
		public override string ModuleDescription => "Allows you to turn off loud sounds";
		public override string ModuleAuthor => "DarkerZ [RUS]";
		public override string ModuleVersion => "1.0";

		public override void Load(bool hotReload)
		{
			HookUserMessage(208, um =>
			{
				var soundevent = um.ReadUInt("soundevent_hash");
				
				if (soundevent == 2149843356 ||	//R8
					soundevent == 576815311 || //Glock and Famas
					soundevent == 62938228 || soundevent == 2831007164 || soundevent == 3573863551 || soundevent == 3535174312 || soundevent == 1193078452 ||//HeadShot
					soundevent == 3767841471 || soundevent == 524041390 || soundevent == 708038349) //Body
				{
					um.Recipients.Clear();
					return HookResult.Stop;
				}
				//var entityIndex = um.ReadInt("source_entity_index");
				//Console.WriteLine($"SoundEvent: {soundevent} EntityIndex: {entityIndex}");
				return HookResult.Continue;

			}, HookMode.Pre);
		}
	}
}
