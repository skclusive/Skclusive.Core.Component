using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skclusive.Core.Component
{
    public class EventComponentBase : CssComponentBase
    {
        public EventComponentBase(string selector = "") : base(selector)
        {
        }

        /// <summary>
        /// onfocus event handler
        /// </summary>
        [Parameter]
        public EventCallback<FocusEventArgs> OnFocus { set; get; }

        /// <summary>
        /// onblur event handler
        /// </summary>
        [Parameter]
        public EventCallback<FocusEventArgs> OnBlur { set; get; }

        /// <summary>
        /// onclick event handler
        /// </summary>
        [Parameter]
        public EventCallback<EventArgs> OnClick { set; get; }

        [Parameter]
        public bool? OnClickStop { set; get; }

        [Parameter]
        public bool? OnClickPrevent { set; get; }

        /// <summary>
        /// ondrag event handler
        /// </summary>
        [Parameter]
        public EventCallback<DragEventArgs> OnDrag { set; get; }

        /// <summary>
        /// ondrop event handler
        /// </summary>
        [Parameter]
        public EventCallback<DragEventArgs> OnDrop { set; get; }

        /// <summary>
        /// ondragstart event handler
        /// </summary>
        [Parameter]
        public EventCallback<DragEventArgs> OnDragStart { set; get; }

        /// <summary>
        /// ondragend event handler
        /// </summary>
        [Parameter]
        public EventCallback<DragEventArgs> OnDragEnd { set; get; }

        /// <summary>
        /// ondragenter event handler
        /// </summary>
        [Parameter]
        public EventCallback<DragEventArgs> OnDragEnter { set; get; }

        /// <summary>
        /// ondragexit event handler
        /// </summary>
        [Parameter]
        public EventCallback<DragEventArgs> OnDragExit { set; get; }

        /// <summary>
        /// ondragover event handler
        /// </summary>
        [Parameter]
        public EventCallback<DragEventArgs> OnDragOver { set; get; }

        /// <summary>
        /// ondragleave event handler
        /// </summary>
        [Parameter]
        public EventCallback<DragEventArgs> OnDragLeave { set; get; }

        /// <summary>
        /// onkeydown event handler
        /// </summary>
        [Parameter]
        public EventCallback<KeyboardEventArgs> OnKeyDown { set; get; }

        /// <summary>
        /// onkeyup event handler
        /// </summary>
        [Parameter]
        public EventCallback<KeyboardEventArgs> OnKeyUp { set; get; }

        [Parameter]
        public bool? OnKeyUpStop { set; get; }

        [Parameter]
        public bool? OnKeyUpPrevent { set; get; }

        /// <summary>
        /// onmousedown event handler
        /// </summary>
        [Parameter]
        public EventCallback<MouseEventArgs> OnMouseDown { set; get; }

        /// <summary>
        /// onmouseup event handler
        /// </summary>
        [Parameter]
        public EventCallback<MouseEventArgs> OnMouseUp { set; get; }

        /// <summary>
        /// onmouseenter event handler
        /// </summary>
        [Parameter]
        public EventCallback<EventArgs> OnMouseEnter { set; get; }

        /// <summary>
        /// onmouseleave event handler
        /// </summary>
        [Parameter]
        public EventCallback<EventArgs> OnMouseLeave { set; get; }

        /// <summary>
        /// onmouseover event handler
        /// </summary>
        [Parameter]
        public EventCallback<MouseEventArgs> OnMouseOver { set; get; }

        /// <summary>
        /// onmouseout event handler
        /// </summary>
        [Parameter]
        public EventCallback<MouseEventArgs> OnMouseOut { set; get; }


        /// <summary>
        /// onmousemove event handler
        /// </summary>
        [Parameter]
        public EventCallback<MouseEventArgs> OnMouseMove { set; get; }

        /// <summary>
        /// ontouchstart event handler
        /// </summary>
        [Parameter]
        public EventCallback<TouchEventArgs> OnTouchStart { set; get; }

        /// <summary>
        /// ontouchend event handler
        /// </summary>
        [Parameter]
        public EventCallback<TouchEventArgs> OnTouchEnd { set; get; }

        /// <summary>
        /// ontouchmove event handler
        /// </summary>
        [Parameter]
        public EventCallback<TouchEventArgs> OnTouchMove { set; get; }

        protected virtual Task HandleFocus(FocusEventArgs args)
        {
            return OnFocus.InvokeAsync(args);
        }

        protected virtual async Task HandleFocusAsync(FocusEventArgs args)
        {
            await HandleFocus(args);
        }

        protected virtual Task HandleBlur(FocusEventArgs args)
        {
            return OnBlur.InvokeAsync(args);
        }

        protected virtual async Task HandleBlurAsync(FocusEventArgs args)
        {
            await HandleBlur(args);
        }

        protected virtual Task HandleKeyDown(KeyboardEventArgs args)
        {
            return OnKeyDown.InvokeAsync(args);
        }

        protected virtual async Task HandleKeyDownAsync(KeyboardEventArgs args)
        {
            await HandleKeyDown(args);
        }

        protected virtual Task HandleKeyUp(KeyboardEventArgs args)
        {
            return OnKeyUp.InvokeAsync(args);
        }

        protected virtual async Task HandleKeyUpAsync(KeyboardEventArgs args)
        {
            await HandleKeyUp(args);
        }

        protected virtual Task HandleMouseDown(MouseEventArgs args)
        {
            return OnMouseDown.InvokeAsync(args);
        }

        protected virtual async Task HandleMouseDownAsync(MouseEventArgs args)
        {
            await HandleMouseDown(args);
        }

        protected virtual Task HandleMouseUp(MouseEventArgs args)
        {
            return OnMouseUp.InvokeAsync(args);
        }

        protected virtual async Task HandleMouseUpAsync(MouseEventArgs args)
        {
            await HandleMouseUp(args);
        }

        protected virtual Task HandleMouseEnter(EventArgs args)
        {
            return OnMouseEnter.InvokeAsync(args);
        }

        protected virtual async Task HandleMouseEnterAsync(EventArgs args)
        {
            await HandleMouseEnter(args);
        }

        protected virtual Task HandleMouseLeave(EventArgs args)
        {
            return OnMouseLeave.InvokeAsync(args);
        }

        protected virtual async Task HandleMouseLeaveAsync(EventArgs args)
        {
            await HandleMouseLeave(args);
        }

        protected virtual async Task HandleMouseOverAsync(MouseEventArgs args)
        {
            await OnMouseOver.InvokeAsync(args);
        }

        protected virtual async Task HandleMouseOutAsync(MouseEventArgs args)
        {
            await OnMouseOut.InvokeAsync(args);
        }

        protected virtual async Task HandleMouseMoveAsync(MouseEventArgs args)
        {
            await OnMouseMove.InvokeAsync(args);
        }

        protected virtual Task HandleTouchStart(TouchEventArgs args)
        {
            return OnTouchStart.InvokeAsync(args);
        }

        protected virtual async Task HandleTouchStartAsync(TouchEventArgs args)
        {
            await HandleTouchStart(args);
        }

        protected virtual Task HandleTouchEnd(TouchEventArgs args)
        {
            return OnTouchEnd.InvokeAsync(args);
        }

        protected virtual async Task HandleTouchEndAsync(TouchEventArgs args)
        {
            await HandleTouchEnd(args);
        }

        protected virtual Task HandleTouchMove(TouchEventArgs args)
        {
            return OnTouchMove.InvokeAsync(args);
        }

        protected virtual async Task HandleTouchMoveAsync(TouchEventArgs args)
        {
            await HandleTouchMove(args);
        }

        protected virtual Task HandleClick(EventArgs args)
        {
            return OnClick.InvokeAsync(args);
        }

        protected virtual async Task HandleClickAsync(EventArgs args)
        {
            await HandleClick(args);
        }

        protected virtual Task HandleDrag(DragEventArgs args)
        {
            return OnDrag.InvokeAsync(args);
        }

        protected virtual async Task HandleDragAsync(DragEventArgs args)
        {
            await HandleDrag(args);
        }

        protected virtual Task HandleDrop(DragEventArgs args)
        {
            return OnDrop.InvokeAsync(args);
        }

        protected virtual async Task HandleDropAsync(DragEventArgs args)
        {
            await HandleDrop(args);
        }

        protected virtual Task HandleDragStart(DragEventArgs args)
        {
            return OnDragStart.InvokeAsync(args);
        }

        protected virtual async Task HandleDragStartAsync(DragEventArgs args)
        {
            await HandleDragStart(args);
        }

        protected virtual Task HandleDragEnd(DragEventArgs args)
        {
            return OnDragEnd.InvokeAsync(args);
        }

        protected virtual async Task HandleDragEndAsync(DragEventArgs args)
        {
            await HandleDragEnd(args);
        }

        protected virtual Task HandleDragEnter(DragEventArgs args)
        {
            return OnDragEnter.InvokeAsync(args);
        }

        protected virtual async Task HandleDragEnterAsync(DragEventArgs args)
        {
            await HandleDragEnter(args);
        }

        protected virtual Task HandleDragExit(DragEventArgs args)
        {
            return OnDragExit.InvokeAsync(args);
        }

        protected virtual async Task HandleDragExitAsync(DragEventArgs args)
        {
            await HandleDragExit(args);
        }

        protected virtual Task HandleDragOver(DragEventArgs args)
        {
            return OnDragOver.InvokeAsync(args);
        }

        protected virtual async Task HandleDragOverAsync(DragEventArgs args)
        {
            await HandleDragOver(args);
        }

        protected virtual Task HandleDragLeave(DragEventArgs args)
        {
            return OnDragLeave.InvokeAsync(args);
        }

        protected virtual async Task HandleDragLeaveAsync(DragEventArgs args)
        {
            await HandleDragLeave(args);
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
