namespace pic_encrypter
{
    internal interface IStrategy<T>
    {
        void CreatePicture(string Path, T Message);
    }
}
