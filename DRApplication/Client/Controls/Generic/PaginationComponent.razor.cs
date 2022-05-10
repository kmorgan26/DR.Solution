using Microsoft.AspNetCore.Components;
using DRApplication.Client.ViewModels.Shared;

namespace DRApplication.Client.Controls.Generic
{
    public partial class PaginationComponent
    {
        [Parameter]
        public int CurrentPage { get; set; }

        [Parameter]
        public int TotalPages { get; set; }

        [Parameter]
        public int Radius { get; set; }

        [Parameter]
        public EventCallback<int> SelectedPage { get; set; }

        [Parameter]
        public int TotalRecords { get; set; }

        List<LinkModel> links = new();
        protected override void OnParametersSet()
        {
            LoadPages();
        }

        private async Task SelectedPageInternal(LinkModel link)
        {
            if (link.PageNumber == CurrentPage)
            {
                return;
            }

            if (!link.Enabled)
            {
                return;
            }

            CurrentPage = link.PageNumber;
            await SelectedPage.InvokeAsync(link.PageNumber);
        }

        private void LoadPages()
        {
            links = new List<LinkModel>();
            var isPreviousPageLinkEnabled = CurrentPage != 1;
            var previousPage = CurrentPage - 1;
            links.Add(new LinkModel(previousPage, isPreviousPageLinkEnabled, "<"));
            for (int i = 1; i <= TotalPages; i++)
            {
                if (i >= CurrentPage - Radius && i <= CurrentPage + Radius)
                {
                    links.Add(new LinkModel(i)
                    {Active = CurrentPage == i});
                }
            }

            var isNextPageLinkEnabled = CurrentPage != TotalPages;
            var nextPage = CurrentPage + 1;
            links.Add(new LinkModel(nextPage, isNextPageLinkEnabled, ">"));
        }
    }
}