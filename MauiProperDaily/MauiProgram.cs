﻿using MauiProperDaily.MVVM.Models;
using MauiProperDaily.Repositories;
using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Core.Hosting;

namespace MauiProperDaily;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureSyncfusionCore()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddFont("Roboto-Black.ttf", "Strong");
				fonts.AddFont("librefranklin-regular.ttf", "Regular");
			});

		builder.Services.AddSingleton<BaseRepository<Transaction>>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
