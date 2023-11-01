import withControlledField from "../withControlledField";
import InputField from "./InputField";
import SelectField from "./selectField";

export const InputFieldControlled = withControlledField((props) => (
  <InputField {...props} />
));

export const SelectFieldControlled = withControlledField((props) => (
  <SelectField {...props} />
));
