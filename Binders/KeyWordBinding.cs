using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Razorweb.Binders
{
    /// <summary>
    /// Chuyển tên thành chữ in hoa
    /// Tên không được chứa ký tự xxx
    /// Cắt khoảng trắng ở đầu và cuối
    /// </summary>
    public class KeyWordBinding : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null) throw new ArgumentNullException("bindingContext");
            string modelName = bindingContext.ModelName;
            // Đọc giá trị gửi đến
            var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);
            if (valueProviderResult == ValueProviderResult.None) return Task.CompletedTask;
            // Do trong giá trị gửi đến ở 1 key có thể có nhiều giá trị(Form/Query/Header/Body/RouterValue) nên ta phải lấy giá trị đầu tiên
            string value = valueProviderResult.FirstValue;
            if (string.IsNullOrEmpty(value)){
                // thiết lập trạng thái ModelState để trả về view khi có lỗi
                bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);
                // Trả về nội dung lỗi
                bindingContext.ModelState.TryAddModelError(modelName, "Không được để trống");
                return Task.CompletedTask;
            }
            // Xử lý binding
            string s = value.ToLower();
            if (s.Contains("xxx"))
            {
                // thiết lập trạng thái ModelState để trả về view khi có lỗi
                bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);
                // Trả về nội dung lỗi
                bindingContext.ModelState.TryAddModelError(modelName, "Lỗi do chứa xxx");
                return Task.CompletedTask;
            }
            s = s.Trim();
            // Thiết lập giá trị cho modelName. Những giá trị này nó lưu trong modelstate
            bindingContext.ModelState.SetModelValue(modelName, s, s);
            bindingContext.Result = ModelBindingResult.Success(s);
            return Task.CompletedTask;

        }
    }
}