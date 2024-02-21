import TextField, { TextFieldProps } from "../ui/fields/TextField";
import withControlledField from "./withControlledField";

export const TextFieldControlled = withControlledField<TextFieldProps>((props) => (
  <TextField {...props} />
));
