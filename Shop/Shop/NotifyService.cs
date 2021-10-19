using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class NotifyService
    {
        public delegate void EventHandler();

        public event EventHandler CreateShowcaseIsDone;
        public event EventHandler CreateProductIsDone;
        public event EventHandler PlaceProductIsDone;
        public event EventHandler EditProductIsDone;
        public event EventHandler DeleteProductIsDone;
        public event EventHandler EditShowcaseIsDone;
        public event EventHandler DeleteShowcaseIsDone;
        public event EventHandler VolumeError;

        //ProductService event
        public event EventHandler ProductIsNotfound;
        public event EventHandler SearchProductIdIsNotSuccessful;

        //ShowcaseService event
        public event EventHandler CountCheck;
        public event EventHandler DeleteError;
        public event EventHandler ChekProductOnShowacse;
        public event EventHandler SearchShowcaseIdIsNotSuccessful;

        public void RaiseCreateShowcaseIsDone()
        {
            CreateShowcaseIsDone?.Invoke();
        }

        public void RaiseCreateProductIsDone()
        {
            CreateProductIsDone?.Invoke();
        }

        public void RaisePlaceProductIsDone()
        {
            PlaceProductIsDone?.Invoke();
        }

        public void RaiseEditProductIsDone()
        {
            EditProductIsDone?.Invoke();
        }

        public void RaiseDeleteProductIsDone()
        {
            DeleteProductIsDone?.Invoke();
        }

        public void RaiseEditShowcaseIsDone()
        {
            EditShowcaseIsDone?.Invoke();
        }

        public void RaiseDeleteShowcaseIsDone()
        {
            DeleteShowcaseIsDone?.Invoke();
        }

        public void RaiseVolumeErrorMessage()
        {
            VolumeError?.Invoke();
        }

        public void RaiseProductIsNotfound()
        {
            ProductIsNotfound?.Invoke();
        }

        public void RaiseSearchProductIdIsNotSuccessful()
        {
            SearchProductIdIsNotSuccessful?.Invoke();
        }

        public void RaiseCountCheck()
        {
            CountCheck?.Invoke();
        }

        public void RaiseDeleteError()
        {
            DeleteError?.Invoke();
        }

        public void RaiseChekProductOnShowacse()
        {
            ChekProductOnShowacse?.Invoke();
        }

        public void RaiseSearchShowcaseIdIsNotSuccessful()
        {
            SearchShowcaseIdIsNotSuccessful?.Invoke();
        }
    }
}
