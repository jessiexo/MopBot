﻿using System.Threading.Tasks;
using Discord.Commands;
using MopBotTwo.Extensions;
using MopBotTwo.Core.Systems.Permissions;
using MopBotTwo.Core.Systems;
using MopBotTwo.Core.Systems.Memory;

namespace MopBotTwo.Common.Systems.MemoryTest
{
	[Group("memorytest")]
	[RequirePermission(SpecialPermission.BotMaster)]
	[SystemConfiguration(AlwaysEnabled = true)]
	public class MemoryTestSystem : BotSystem
	{
		public override void RegisterDataTypes()
		{
			RegisterDataType<UserMemory,MemoryTestUserData>();
			RegisterDataType<ServerMemory,MemoryTestServerData>();
			RegisterDataType<ServerUserMemory,MemoryTestServerUserData>();
		}

		[Command]
		public async Task Command()
		{
			var memory = MemorySystem.memory;
			var userMemory = memory[Context.User];
			var serverMemory = memory[Context.Guild];
			var serverUserMemory = serverMemory[Context.User];

			await Context.ReplyAsync(
				$"**{nameof(MemoryTestUserData)}.{nameof(MemoryTestUserData.randomValue)}**: `{userMemory.GetData<MemoryTestSystem,MemoryTestUserData>().randomValue}`\r\n"+
				$"**{nameof(MemoryTestServerData)}.{nameof(MemoryTestServerData.randomValue)}**: `{serverMemory.GetData<MemoryTestSystem,MemoryTestServerData>().randomValue}`\r\n"+
				$"**{nameof(MemoryTestServerUserData)}.{nameof(MemoryTestServerUserData.randomValue)}**: `{serverUserMemory.GetData<MemoryTestSystem,MemoryTestServerUserData>().randomValue}`\r\n"
			);
		}
		[Command("reset")]
		public async Task Reset()
		{
			var memory = MemorySystem.memory;
			var userMemory = memory[Context.User];
			var serverMemory = memory[Context.Guild];
			var serverUserMemory = serverMemory[Context.User];

			userMemory.ResetData<MemoryTestSystem,MemoryTestUserData>();
			serverMemory.ResetData<MemoryTestSystem,MemoryTestServerData>();
			serverUserMemory.ResetData<MemoryTestSystem,MemoryTestServerUserData>();
		}
	}
}