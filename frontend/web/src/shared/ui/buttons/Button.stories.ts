import type { Meta, StoryObj } from '@storybook/react';
import Button from './Button';

const meta = {
  title: 'shared/ui/button',
  component: Button,
  tags: ['autodocs'],
  parameters: {
    layout: 'fullscreen',
  },
} satisfies Meta<typeof Button>;

export default meta;
type Story = StoryObj<typeof meta>;

export const LoggedIn: Story = {
  args: {
    children: 'Tomek'
  },
};

export const LoggedOut: Story = {};
