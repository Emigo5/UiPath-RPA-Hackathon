using System;
using System.Activities;
using System.Threading;
using System.Threading.Tasks;
using GetFileFoldeInfo.Activities.Properties;
using UiPath.Shared.Activities;
using UiPath.Shared.Activities.Localization;

namespace GetFileFoldeInfo.Activities
{
    [LocalizedDisplayName(nameof(Resources.GetFileName_DisplayName))]
    [LocalizedDescription(nameof(Resources.GetFileName_Description))]
    public class GetFileName : ContinuableAsyncCodeActivity
    {
        #region Properties

        /// <summary>
        /// If set, continue executing the remaining activities even if the current activity has failed.
        /// </summary>
        [LocalizedCategory(nameof(Resources.Common_Category))]
        [LocalizedDisplayName(nameof(Resources.ContinueOnError_DisplayName))]
        [LocalizedDescription(nameof(Resources.ContinueOnError_Description))]
        public override InArgument<bool> ContinueOnError { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetFileName_FilePath_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetFileName_FilePath_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> FilePath { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetFileName_FileName_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetFileName_FileName_Description))]
        [LocalizedCategory(nameof(Resources.Output_Category))]
        public OutArgument<string> FileName { get; set; }

        #endregion


        #region Constructors

        public GetFileName()
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
    
            ///////////////////////////
            // Add execution logic HERE
            ///////////////////////////

            // Outputs
            return (ctx) => {
                FileName.Set(ctx, null);
            };
        }

        #endregion
    }
}

