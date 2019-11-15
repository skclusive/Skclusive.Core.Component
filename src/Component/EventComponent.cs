using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skclusive.Core.Component
{
    public class EventComponent : CssComponent
    {
        public EventComponent(string selector = "") : base(selector)
        {
        }

        [Parameter]
        public EventCallback<FocusEventArgs> OnFocus { set; get; }

        [Parameter]
        public EventCallback<FocusEventArgs> OnBlur { set; get; }

        [Parameter]
        public EventCallback<EventArgs> OnClick { set; get; }

        [Parameter]
        public EventCallback<DragEventArgs> OnDrag { set; get; }

        [Parameter]
        public EventCallback<DragEventArgs> OnDrop { set; get; }

        [Parameter]
        public EventCallback<DragEventArgs> OnDragStart { set; get; }

        [Parameter]
        public EventCallback<DragEventArgs> OnDragEnd { set; get; }

        [Parameter]
        public EventCallback<DragEventArgs> OnDragEnter { set; get; }

        [Parameter]
        public EventCallback<DragEventArgs> OnDragExit { set; get; }

        [Parameter]
        public EventCallback<DragEventArgs> OnDragOver { set; get; }

        [Parameter]
        public EventCallback<DragEventArgs> OnDragLeave { set; get; }

        [Parameter]
        public EventCallback<KeyboardEventArgs> OnKeyDown { set; get; }

        [Parameter]
        public EventCallback<KeyboardEventArgs> OnKeyUp { set; get; }

        [Parameter]
        public EventCallback<MouseEventArgs> OnMouseDown { set; get; }

        [Parameter]
        public EventCallback<MouseEventArgs> OnMouseUp { set; get; }

        [Parameter]
        public EventCallback<EventArgs> OnMouseLeave { set; get; }

        [Parameter]
        public EventCallback<TouchEventArgs> OnTouchStart { set; get; }

        [Parameter]
        public EventCallback<TouchEventArgs> OnTouchEnd { set; get; }

        [Parameter]
        public EventCallback<TouchEventArgs> OnTouchMove { set; get; }

        protected virtual void HandleFocus(FocusEventArgs args)
        {
            OnFocus.InvokeAsync(args);
        }

        protected virtual Task HandleFocusAsync(FocusEventArgs args)
        {
            HandleFocus(args);

            return Task.CompletedTask;
        }

        protected virtual void HandleBlur(FocusEventArgs args)
        {
            OnBlur.InvokeAsync(args);
        }

        protected virtual Task HandleBlurAsync(FocusEventArgs args)
        {
            HandleBlur(args);

            return Task.CompletedTask;
        }

        protected virtual void HandleKeyDown(KeyboardEventArgs args)
        {
            OnKeyDown.InvokeAsync(args);
        }

        protected virtual Task HandleKeyDownAsync(KeyboardEventArgs args)
        {
            HandleKeyDown(args);

            return Task.CompletedTask;
        }

        protected virtual void HandleKeyUp(KeyboardEventArgs args)
        {
            OnKeyUp.InvokeAsync(args);
        }

        protected virtual Task HandleKeyUpAsync(KeyboardEventArgs args)
        {
            HandleKeyUp(args);

            return Task.CompletedTask;
        }

        protected virtual void HandleMouseDown(MouseEventArgs args)
        {
            OnMouseDown.InvokeAsync(args);
        }

        protected virtual Task HandleMouseDownAsync(MouseEventArgs args)
        {
            HandleMouseDown(args);

            return Task.CompletedTask;
        }

        protected virtual void HandleMouseUp(MouseEventArgs args)
        {
            OnMouseUp.InvokeAsync(args);
        }

        protected virtual Task HandleMouseUpAsync(MouseEventArgs args)
        {
            HandleMouseUp(args);

            return Task.CompletedTask;
        }

        protected virtual void HandleMouseLeave(EventArgs args)
        {
            OnMouseLeave.InvokeAsync(args);
        }

        protected virtual Task HandleMouseLeaveAsync(EventArgs args)
        {
            HandleMouseLeave(args);

            return Task.CompletedTask;
        }

        protected virtual void HandleTouchStart(TouchEventArgs args)
        {
            OnTouchStart.InvokeAsync(args);
        }

        protected virtual Task HandleTouchStartAsync(TouchEventArgs args)
        {
            HandleTouchStart(args);

            return Task.CompletedTask;
        }

        protected virtual void HandleTouchEnd(TouchEventArgs args)
        {
            OnTouchEnd.InvokeAsync(args);
        }

        protected virtual Task HandleTouchEndAsync(TouchEventArgs args)
        {
            HandleTouchEnd(args);

            return Task.CompletedTask;
        }

        protected virtual void HandleTouchMove(TouchEventArgs args)
        {
            OnTouchMove.InvokeAsync(args);
        }

        protected virtual Task HandleTouchMoveAsync(TouchEventArgs args)
        {
            HandleTouchMove(args);

            return Task.CompletedTask;
        }

        protected virtual void HandleClick(EventArgs args)
        {
            OnClick.InvokeAsync(args);
        }

        protected virtual Task HandleClickAsync(EventArgs args)
        {
            HandleClick(args);

            return Task.CompletedTask;
        }

        protected virtual void HandleDrag(DragEventArgs args)
        {
            OnDrag.InvokeAsync(args);
        }

        protected virtual Task HandleDragAsync(DragEventArgs args)
        {
            HandleDrag(args);

            return Task.CompletedTask;
        }

        protected virtual void HandleDrop(DragEventArgs args)
        {
            OnDrop.InvokeAsync(args);
        }

        protected virtual Task HandleDropAsync(DragEventArgs args)
        {
            HandleDrop(args);

            return Task.CompletedTask;
        }

        protected virtual void HandleDragStart(DragEventArgs args)
        {
            OnDragStart.InvokeAsync(args);
        }

        protected virtual Task HandleDragStartAsync(DragEventArgs args)
        {
            HandleDragStart(args);

            return Task.CompletedTask;
        }

        protected virtual void HandleDragEnd(DragEventArgs args)
        {
            OnDragEnd.InvokeAsync(args);
        }

        protected virtual Task HandleDragEndAsync(DragEventArgs args)
        {
            HandleDragEnd(args);

            return Task.CompletedTask;
        }

        protected virtual void HandleDragEnter(DragEventArgs args)
        {
            OnDragEnter.InvokeAsync(args);
        }

        protected virtual Task HandleDragEnterAsync(DragEventArgs args)
        {
            HandleDragEnter(args);

            return Task.CompletedTask;
        }

        protected virtual void HandleDragExit(DragEventArgs args)
        {
            OnDragExit.InvokeAsync(args);
        }

        protected virtual Task HandleDragExitAsync(DragEventArgs args)
        {
            HandleDragExit(args);

            return Task.CompletedTask;
        }

        protected virtual void HandleDragOver(DragEventArgs args)
        {
            OnDragOver.InvokeAsync(args);
        }

        protected virtual Task HandleDragOverAsync(DragEventArgs args)
        {
            HandleDragOver(args);

            return Task.CompletedTask;
        }

        protected virtual void HandleDragLeave(DragEventArgs args)
        {
            OnDragLeave.InvokeAsync(args);
        }

        protected virtual Task HandleDragLeaveAsync(DragEventArgs args)
        {
            HandleDragLeave(args);

            return Task.CompletedTask;
        }

        protected void Debug(ParameterView parameters)
        {
            Debug(parameters.ToDictionary());
        }

        protected void Debug(IEnumerable<KeyValuePair<string, object>> parameters)
        {
            var _params = parameters.Select(pair => $"key: {pair.Key}, value: {pair.Value}");

            var paramsline = string.Join("\n", _params);

            Console.WriteLine(paramsline);
        }
    }
}
