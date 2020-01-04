﻿using System;
using Discord.Commands;

namespace MopBotTwo.Core.TypeReaders
{
	public abstract class CustomTypeReader : TypeReader
	{
		public abstract Type[] Types { get; }

		protected CustomTypeReader() { }
	}
}
