import type { FormRef } from "~/types/form.types.ts";

import { zodResolver } from "@hookform/resolvers/zod";
import { type FormEvent, type ForwardedRef, useImperativeHandle } from "react";
import { type DefaultValues, useForm } from "react-hook-form";
import { ZodEffects, type ZodObject, type ZodRawShape, type ZodTypeAny, type z } from "zod";

type FormDataShape = ZodEffects<ZodTypeAny> | ZodObject<ZodRawShape>;

export interface UseFormManagerProps<T extends FormDataShape, U extends z.infer<T>> {
  defaultValues: DefaultValues<U>;
  onSubmit: (data: U) => void;
  ref?: ForwardedRef<FormRef<U>>;
  schema: T;
}

export default function useFormManager<T extends FormDataShape, U extends z.infer<T>>({
  defaultValues,
  onSubmit,
  ref,
  schema,
}: UseFormManagerProps<T, U>) {
  const formMethods = useForm<U>({
    defaultValues,
    resolver: zodResolver(schema),
  });
  const { formState, handleSubmit } = formMethods;
  const { isDirty, isSubmitted, isValid } = formState;

  function submit(event?: FormEvent<HTMLFormElement>) {
    event?.preventDefault();
    handleSubmit(onSubmit)();
  }

  function isFormDirty(): boolean {
    return isDirty;
  }

  function isFormValid(): boolean {
    return isValid;
  }

  function isFormSubmitted(): boolean {
    return isSubmitted;
  }

  useImperativeHandle(ref, () => ({
    isDirty: isFormDirty,
    isSubmitted: isFormSubmitted,
    isValid: isFormValid,
    reset: formMethods.reset,
    submit,
  }));

  return {
    ...formMethods,
    isDirty: isFormDirty,
    isSubmitted: isFormSubmitted,
    isValid: isFormValid,
    submit,
  };
}
