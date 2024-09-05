import { LoadingButton, type LoadingButtonProps } from "@mui/lab";
import { styled } from "@mui/system";

export interface FormSubmitButton extends LoadingButtonProps {}

export default function FormSubmitButton(props: LoadingButtonProps) {
  return (
    <StyledLoadingButton variant={"contained"} {...props} type={"submit"}>
      Submit
    </StyledLoadingButton>
  );
}

const StyledLoadingButton = styled(LoadingButton)(({ hidden }) => ({
  display: hidden ? "none" : "block",
}));
