namespace Lab01.Models
{
    public class TestModel
    {
        public async Task<string> AAsync()
        {
            await Task.Delay(2000);
            return "Sleep 2s";
        }

        public async Task<int> BAsync()
        {
            await Task.Delay(5000);
            return 5;
        }

        public async Task CAsync()
        {
            await Task.Delay(3000);
        }

        public string A()
        {
            Thread.Sleep(2000);
            return "Sleep 2s";
        }

        public int B()
        {
            Thread.Sleep(5000);
            return 5;
        }

        public void C()
        {
            Thread.Sleep(3000);
        }
    }
}
