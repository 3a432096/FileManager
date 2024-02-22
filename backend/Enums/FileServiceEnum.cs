namespace FileManager.Enums
{
    public enum FileServiceEnum
    {
        /// <summary>
        /// 本機檔案系統
        /// </summary>
        Local,
        /// <summary>
        /// Azure檔案系統
        /// </summary>
        Azure,
        /// <summary>
        /// Google雲端硬碟
        /// </summary>
        GoogleDrive,
        /// <summary>
        /// Redis Storage
        /// </summary>
        Redis
    }
}
