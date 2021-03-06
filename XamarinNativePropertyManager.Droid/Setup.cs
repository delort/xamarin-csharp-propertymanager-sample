/*
 *  Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license.
 *  See LICENSE in the source repository root for complete license information.
 */

using Android.Content;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using MvvmCross.Platform;
using XamarinNativePropertyManager.Services;
using XamarinNativePropertyManager.Droid.Services;
using System;
using System.Collections.Generic;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Plugins.Visibility;
using XamarinNativePropertyManager.Droid.Converters;

namespace XamarinNativePropertyManager.Droid
{
    public class Setup : MvxAppCompatSetup
    {
        protected override IEnumerable<Type> ValueConverterHolders => new List<Type>
        {
            typeof(MvxVisibilityValueConverter),
            typeof(MvxInvertedVisibilityValueConverter),
            typeof(FileTypeToIconConverter),
        };

        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {            
            // Register platform services.
            Mvx.RegisterSingleton(typeof(IAuthenticationService), new AuthenticationService());
            Mvx.RegisterSingleton(typeof(ILauncherService), new LauncherService());
            Mvx.RegisterSingleton(typeof(IFilePickerService), new FilePickerService());
            Mvx.RegisterSingleton(typeof(IDialogService), new DialogService());
            return new App();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }
    }
}
