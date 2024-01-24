using Microsoft.JSInterop;

namespace NTDataHiveFrontend
{
    public static class FileUtils
    {
        public static ValueTask<object> SaveAs(this IJSRuntime js, string filename, byte[] data)
            => js.InvokeAsync<object>(
                "SaveAsFile",
                filename,
                Convert.ToBase64String(data));
    }
}
