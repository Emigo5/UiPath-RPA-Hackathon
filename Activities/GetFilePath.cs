using System;
using System.Activities;
using System.Threading;
using System.Threading.Tasks;
using GetFileFoldeInfo.Activities.Properties;
using UiPath.Shared.Activities;
using UiPath.Shared.Activities.Localization;
using System.IO;

namespace GetFileFoldeInfo.Activities
{
    [LocalizedDisplayName(nameof(Resources.GetFilePath_DisplayName))]
    [LocalizedDescription(nameof(Resources.GetFilePath_Description))]
    public class GetFilePath : ContinuableAsyncCodeActivity
    {
        #region Properties

        /// <summary>
        /// If set, continue executing the remaining activities even if the current activity has failed.
        /// </summary>
        [LocalizedCategory(nameof(Resources.Common_Category))]
        [LocalizedDisplayName(nameof(Resources.ContinueOnError_DisplayName))]
        [LocalizedDescription(nameof(Resources.ContinueOnError_Description))]
        public override InArgument<bool> ContinueOnError { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetFilePath_FolderPath_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetFilePath_FolderPath_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> FolderPath { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetFilePath_FilePattern_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetFilePath_FilePattern_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> FilePattern { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetFilePath_FilePath_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetFilePath_FilePath_Description))]
        [LocalizedCategory(nameof(Resources.Output_Category))]
        public OutArgument<String[]> FilePath { get; set; }

        #endregion


        #region Constructors

        public GetFilePath()
        {
        }

        #endregion


        #region Protected Methods

        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {
            if (FolderPath == null) metadata.AddValidationError(string.Format(Resources.ValidationValue_Error, nameof(FolderPath)));
            if (FilePattern == null) metadata.AddValidationError(string.Format(Resources.ValidationValue_Error, nameof(FilePattern)));

            base.CacheMetadata(metadata);
        }

        protected override async Task<Action<AsyncCodeActivityContext>> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken)
        {
            // Inputs
            var folderpath = FolderPath.Get(context);
            var filepattern = FilePattern.Get(context);

            string[] filepath = Directory.GetFiles(@folderpath, filepattern);

            // Outputs
            return (ctx) => {
                FilePath.Set(ctx, filepath);
            };
        }

        #endregion
    }
}

