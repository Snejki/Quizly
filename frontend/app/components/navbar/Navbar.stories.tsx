import { Meta, StoryObj } from "@storybook/react";
import Navbar from "./Navbar";


const meta: Meta<typeof Navbar> = {
    component: Navbar,
    title: 'Example/Navbar',
    tags: ['autodocs'],

} satisfies Meta<typeof Navbar>;

export default meta;

type Story = StoryObj<typeof Navbar>

export const NavbarDefault:  Story = {
    render: () => <Navbar />
}