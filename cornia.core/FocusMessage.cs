namespace cornia.core
{
    public static class FocusMessage
    {

        public static string GetResourceResultCodeValue(FocusConstants.FocusResultCode Code)
        {
            string returnMsg = "";
            if (Code.ToString() == "Exception")
            {
                returnMsg = FocusConstants.EnceptionErrorMsg;
            }
            else returnMsg = cornia.core.Resource.Resource.ResourceManager.GetString("ResultCode" + Code.ToString());
            return returnMsg;
        }
    }
}
