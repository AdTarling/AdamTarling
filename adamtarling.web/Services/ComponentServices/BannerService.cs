using adamtarling.web.Constants;
using adamtarling.web.Models;
using adamtarling.web.Services.ComponentServices.Interfaces;
using adamtarling.web.Services.CoreSevices;
using adamtarling.web.Services.CoreSevices.Interfaces;
using adamtarling.web.ViewModels.Components;
using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Web;
using adamtarling.web.ExtensionMethods;
using System.Linq;

namespace adamtarling.web.Services.ComponentServices
{
    public class BannerService : ComponentBaseService, IBannerService
    {
        private readonly IHeaderService _headerService;
        private readonly IMediaModelService _mediaModelService;

        public BannerService()
        {
            _headerService = new HeaderService();
            _mediaModelService = new MediaModelService();
        }

        public BannerViewModel GetViewModel(IPublishedContent componentContent)
        {
            var viewModel = new BannerViewModel
            {
                BackgroundImage = new MediaModel(),
                BannerSlides = new List<BannerSlide>()
            };

            if (componentContent == null)
            {
                return viewModel;
            }

            PopulateComponentBaseProperties(viewModel, componentContent);

            var headerContent = componentContent
                .GetPropertyValue<IEnumerable<IPublishedContent>>(PropertyAliases.Banner.Header);

            if (!headerContent.IsNullOrEmpty())
            {
                viewModel.HeaderViewModel = _headerService.GetViewModel(headerContent.First());
            }        

            viewModel.BackgroundImage = _mediaModelService
                .GetMediaModel(componentContent.GetPropertyValue<IPublishedContent>(PropertyAliases.Banner.BackgroundImage));

            var bannerSlidesContent = componentContent
                .GetPropertyValue<IEnumerable<IPublishedContent>>(PropertyAliases.Banner.BannerSlides);

            if(bannerSlidesContent != null)
            {
                viewModel.BannerSlides = GetBannerSlides(bannerSlidesContent);
            }

            return viewModel;
        }

        private IEnumerable<BannerSlide> GetBannerSlides(IEnumerable<IPublishedContent> bannerSlidesContent)
        {
            var bannerSlides = new List<BannerSlide>();

            if (bannerSlidesContent.IsNullOrEmpty())
            {
                return bannerSlides;
            }

            foreach (var bannerSlideContentItem in bannerSlidesContent)
            {
                bannerSlides.Add(GetBannerSlide(bannerSlideContentItem));
            }

            return bannerSlides;
        }

        private BannerSlide GetBannerSlide(IPublishedContent bannerSlideContentItem)
        {
            var bannerSlide = new BannerSlide();

            if(bannerSlideContentItem == null)
            {
                return bannerSlide;
            }

            bannerSlide.Title = bannerSlideContentItem.GetPropertyValue<string>(PropertyAliases.BannerSlide.Title);
            bannerSlide.Subtitle = bannerSlideContentItem.GetPropertyValue<string>(PropertyAliases.BannerSlide.Subtitle);
            bannerSlide.Copy = bannerSlideContentItem.GetPropertyValue<string>(PropertyAliases.BannerSlide.Copy);

            return bannerSlide;
        }
    }
}