let handleOutsideClick: any;

export default {
  bind(el: any, binding: any) {
    handleOutsideClick = (event: any) => {
      if (!el.contains(event.target)) {
        binding.value();
      }
    };

    document.addEventListener("click", handleOutsideClick);
    document.addEventListener("touchstart", handleOutsideClick);
  },
  unbind() {
    document.removeEventListener("click", handleOutsideClick);
    document.removeEventListener("touchstart", handleOutsideClick);
  }
};