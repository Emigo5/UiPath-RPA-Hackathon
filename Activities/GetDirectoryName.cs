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
    [LocalizedDisplayName(nameof(Resources.GetDirectoryName_DisplayName))]
    [LocalizedDescription(nameof(Resources.GetDirectoryName_Description))]
    public class GetDirectoryName : ContinuableAsyncCodeActivity
    {
        #region Properties

        /// <summary>
        /// If set, continue executing the remaining activities even if the current activity has failed.
        /// </summary>
        [LocalizedCategory(nameof(Resources.Common_Category))]
        [LocalizedDisplayName(nameof(Resources.ContinueOnError_DisplayName))]
        [LocalizedDescription(nameof(Resources.ContinueOnError_Description))]
        public override InArgument<bool> ContinueOnError { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetDirectoryName_FilePath_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetDirectoryName_FilePath_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> FilePath { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetDirectoryName_DirectoryName_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetDirectoryName_DirectoryName_Description))]
        [LocalizedCategory(nameof(Resources.Output_Category))]
        public OutArgument<string> DirectoryName { get; set; }

        #endregion


        #region Constructors

        public GetDirectoryName()
        {
        }

        #endregion


        #region Protected Methods

        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {
            if (FilePath == null) metadata.AddValidationError(string.Format(Resources.ValidationValue_Error, nameof(FilePath)));

            base.CacheMetadata(metadata);
        }

        protected override async Task<Action<AsyncCodeActivityContext>> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken)
        {
            // Inputs
            var filepath = FilePath.Get(context);

            var directoryName = Path.GetDirectoryName(@filepath);

            // Outputs
            return (ctx) => {
                DirectoryName.Set(ctx, directoryName);
            };
        }

        #endregion
    }
}

