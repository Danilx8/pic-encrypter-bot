namespace pic_encrypter
{
    internal interface IStrategy
    {
        void CreatePicture(string Path, string Message);
    }
}
