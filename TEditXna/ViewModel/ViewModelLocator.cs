﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using TEditXna.Editor.Tools;

namespace TEditXna.ViewModel
{
    public static class ViewModelLocator
    {
        static ViewModelLocator()
        {
            _worldViewModel = CreateWorldViewModel();
        }

        private static WorldViewModel _worldViewModel;
        public static WorldViewModel WorldViewModel
        {
            get
            {
                if (_worldViewModel != null) return _worldViewModel;

                WorldViewModel temp = CreateWorldViewModel();
                Interlocked.CompareExchange(ref _worldViewModel, temp, null);
                return _worldViewModel;
            }
        }

        private static WorldViewModel CreateWorldViewModel()
        {
            var wvm = new WorldViewModel();
            wvm.Tools.Add(new PasteTool(wvm));
            var defaultTool = new ArrowTool(wvm);
            wvm.Tools.Add(defaultTool);
            wvm.Tools.Add(new SelectionTool(wvm));
            wvm.Tools.Add(new PickerTool(wvm));
            wvm.Tools.Add(new PencilTool(wvm));
            wvm.Tools.Add(new BrushTool(wvm));
            wvm.Tools.Add(new FillTool(wvm));
            wvm.Tools.Add(new PointTool(wvm));
            wvm.Tools.Add(new SpriteTool(wvm));
            wvm.ActiveTool = defaultTool;
            return wvm;
        }
    }
}