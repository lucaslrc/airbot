using System.Collections.Generic;
using airbot.Services.Models;

namespace airbot.Services.Helpers
{
    public class CloudReportingList
    {
        public List<CloudReportingModel> CloudReporting = new List<CloudReportingModel>()
        {
            new CloudReportingModel { Condition = "SKC", DecoderCondition = "Sky clear" },
            new CloudReportingModel { Condition = "NCD", DecoderCondition = "No cloud detected" },
            new CloudReportingModel { Condition = "CLR", DecoderCondition = "No clouds below a certain altitude" },
            new CloudReportingModel { Condition = "NSC", DecoderCondition = "No significant cloud" },
            new CloudReportingModel { Condition = "FEW", DecoderCondition = "Few cloud layer" },
            new CloudReportingModel { Condition = "SCT", DecoderCondition = "Scattered cloud layer" },
            new CloudReportingModel { Condition = "BKN", DecoderCondition = "Broken cloud layer" },
            new CloudReportingModel { Condition = "OVC", DecoderCondition = "Overcast cloud layer" },
            new CloudReportingModel { Condition = "TCU", DecoderCondition = "Towering Cumulus" },
            new CloudReportingModel { Condition = "VV", DecoderCondition = "Vertical Visibility" },
        };
    }
}