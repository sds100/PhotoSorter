﻿using System.Collections.Generic;
using System.IO;

namespace PhotoSorter.MainForm
{
    class Presenter : IPresenter
    {
        private const string DEBUG_SOURCE = "../../DEBUG_SOURCE";
        private const string DEBUG_OUTPUT = "../../OUTPUT";

        private readonly IForm Form;

        public Presenter(IForm form)
        {
            Form = form;
        }

        public void SortPreview(bool inDebugMode, IProgressDialog progressDialog)
        {
            var groupFormats = Form.SelectedGroupFormats;
            string sourceDirectory = Form.SourceDirectory;
            string outputDirectory = Form.OutputDirectory;

            if (inDebugMode)
            {
                groupFormats = new List<string>()
                {
                    GroupName.YEAR_FORMAT,
                    GroupName.MONTH_FORMAT,
                    GroupName.DAY_FORMAT,
                    GroupName.HOUR_FORMAT
                };

                sourceDirectory = DEBUG_SOURCE;
                outputDirectory = DEBUG_OUTPUT;
            }
            else if (!AreOptionsValid())
            {
                return;
            }

            var backgroundWorker = new SortPreviewBackgroundWorker();

            var args = new SortPreviewBackgroundWorker.Arguments(
                sourceDirectory,
                outputDirectory,
                groupFormats
                );

            progressDialog.SubscribeToBackgroundWorker(backgroundWorker);

            backgroundWorker.RunWorkerCompleted += Form.OnSortPreviewComplete;

            backgroundWorker.RunWorkerAsync(args);

            progressDialog.Show();
        }

        private bool AreOptionsValid()
        {
            if (string.IsNullOrWhiteSpace(Form.SourceDirectory)
                || !Directory.Exists(Form.SourceDirectory))
            {
                Form.ShowMessage("Must choose a valid source directory", isError: true);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(Form.OutputDirectory)
                || !Directory.Exists(Form.OutputDirectory))
            {
                Form.ShowMessage("Must choose a valid output directory", isError: true);
                return false;
            }
            else if (Form.SelectedGroupFormats.Count == 0)
            {
                Form.ShowMessage("Must choose at least one group", isError: true);
                return false;
            }

            Form.ShowMessage("", isError: false);

            return true;
        }
    }
}
