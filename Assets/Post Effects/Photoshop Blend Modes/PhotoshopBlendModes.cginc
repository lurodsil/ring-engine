//Add
float Add(float base, float blend) {
	return min(base + blend, 1.0);
}
float3 Add(float3 base, float3 blend) {
	return min(base + blend, float(1.0));
}
float3 Add(float3 base, float3 blend, float opacity) {
	return (Add(base, blend) * opacity + base * (1.0 - opacity));
}

//Average
float3 Average(float3 base, float3 blend) {
	return (base + blend) / 2.0;
}
float3 Average(float3 base, float3 blend, float opacity) {
	return (Average(base, blend) * opacity + base * (1.0 - opacity));
}

//Color Burn
float ColorBurn(float base, float blend) {
	return (blend == 0.0) ? blend : max((1.0 - ((1.0 - base) / blend)), 0.0);
}
float3 ColorBurn(float3 base, float3 blend) {
	return float3(ColorBurn(base.r, blend.r), ColorBurn(base.g, blend.g), ColorBurn(base.b, blend.b));
}
float3 ColorBurn(float3 base, float3 blend, float opacity) {
	return (ColorBurn(base, blend) * opacity + base * (1.0 - opacity));
}

//Color Dodge
float ColorDodge(float base, float blend) {
	return (blend == 1.0) ? blend : min(base / (1.0 - blend), 1.0);
}
float3 ColorDodge(float3 base, float3 blend) {
	return float3(ColorDodge(base.r, blend.r), ColorDodge(base.g, blend.g), ColorDodge(base.b, blend.b));
}
float3 ColorDodge(float3 base, float3 blend, float opacity) {
	return (ColorDodge(base, blend) * opacity + base * (1.0 - opacity));
}

//Darken
float Darken(float base, float blend) {
	return min(blend, base);
}
float3 Darken(float3 base, float3 blend) {
	return float3(Darken(base.r, blend.r), Darken(base.g, blend.g), Darken(base.b, blend.b));
}
float3 Darken(float3 base, float3 blend, float opacity) {
	return (Darken(base, blend) * opacity + base * (1.0 - opacity));
}

//Difference
float3 Difference(float3 base, float3 blend) {
	return abs(base - blend);
}
float3 Difference(float3 base, float3 blend, float opacity) {
	return (Difference(base, blend) * opacity + base * (1.0 - opacity));
}

//Divide
float3 Divide(float3 base, float3 blend) {
	return min(1, base/blend);
}
float3 Divide(float3 base, float3 blend, float opacity) {
	return (Divide(base, blend) * opacity + base * (1.0 - opacity));
}

//Exclusion
float3 Exclusion(float3 base, float3 blend) {
	return base + blend - 2.0*base*blend;
}
float3 Exclusion(float3 base, float3 blend, float opacity) {
	return (Exclusion(base, blend) * opacity + base * (1.0 - opacity));
}

//Reflect
float Reflect(float base, float blend) {
	return (blend == 1.0) ? blend : min(base*base / (1.0 - blend), 1.0);
}
float3 Reflect(float3 base, float3 blend) {
	return float3(Reflect(base.r, blend.r), Reflect(base.g, blend.g), Reflect(base.b, blend.b));
}
float3 Reflect(float3 base, float3 blend, float opacity) {
	return (Reflect(base, blend) * opacity + base * (1.0 - opacity));
}

//Glow
float3 Glow(float3 base, float3 blend) {
	return Reflect(blend, base);
}
float3 Glow(float3 base, float3 blend, float opacity) {
	return (Glow(base, blend) * opacity + base * (1.0 - opacity));
}

//Overlay
float Overlay(float base, float blend) {
	return base < 0.5 ? (2.0*base*blend) : (1.0 - 2.0*(1.0 - base)*(1.0 - blend));
}
float3 Overlay(float3 base, float3 blend) {
	return float3(Overlay(base.r, blend.r), Overlay(base.g, blend.g), Overlay(base.b, blend.b));
}
float3 Overlay(float3 base, float3 blend, float opacity) {
	return (Overlay(base, blend) * opacity + base * (1.0 - opacity));
}

//Hard Light
float3 HardLight(float3 base, float3 blend) {
	return Overlay(blend, base);
}
float3 HardLight(float3 base, float3 blend, float opacity) {
	return (HardLight(base, blend) * opacity + base * (1.0 - opacity));
}

//Vivid Light
float VividLight(float base, float blend) {
	return (blend < 0.5) ? ColorBurn(base, (2.0*blend)) : ColorDodge(base, (2.0*(blend - 0.5)));
}
float3 VividLight(float3 base, float3 blend) {
	return float3(VividLight(base.r, blend.r), VividLight(base.g, blend.g), VividLight(base.b, blend.b));
}
float3 VividLight(float3 base, float3 blend, float opacity) {
	return (VividLight(base, blend) * opacity + base * (1.0 - opacity));
}

//Hard Mix
float HardMix(float base, float blend) {
	return (VividLight(base, blend) < 0.5) ? 0.0 : 1.0;
}
float3 HardMix(float3 base, float3 blend) {
	return float3(HardMix(base.r, blend.r), HardMix(base.g, blend.g), HardMix(base.b, blend.b));
}
float3 HardMix(float3 base, float3 blend, float opacity) {
	return (HardMix(base, blend) * opacity + base * (1.0 - opacity));
}

//Lighten
float Lighten(float base, float blend) {
	return max(blend, base);
}
float3 Lighten(float3 base, float3 blend) {
	return float3(Lighten(base.r, blend.r), Lighten(base.g, blend.g), Lighten(base.b, blend.b));
}
float3 Lighten(float3 base, float3 blend, float opacity) {
	return (Lighten(base, blend) * opacity + base * (1.0 - opacity));
}

//Linear Burn
float LinearBurn(float base, float blend) {
	// Note : Same implementation as Subtractf
	return max(base + blend - 1.0, 0.0);
}
float3 LinearBurn(float3 base, float3 blend) {
	// Note : Same implementation as Subtract
	return max(base + blend - float3(1.0, 1.0, 1.0), float3(0.0, 0.0, 0.0));
}
float3 LinearBurn(float3 base, float3 blend, float opacity) {
	return (LinearBurn(base, blend) * opacity + base * (1.0 - opacity));
}

//LinearDodge
float LinearDodge(float base, float blend) {
	// Note : Same implementation as Addf
	return min(base + blend, 1.0);
}
float3 LinearDodge(float3 base, float3 blend) {
	// Note : Same implementation as Add
	return min(base + blend, float3(1.0, 1.0, 1.0));
}
float3 LinearDodge(float3 base, float3 blend, float opacity) {
	return (LinearDodge(base, blend) * opacity + base * (1.0 - opacity));
}

//Linear Light
float LinearLight(float base, float blend) {
	return blend < 0.5 ? LinearBurn(base, (2.0*blend)) : LinearDodge(base, (2.0*(blend - 0.5)));
}
float3 LinearLight(float3 base, float3 blend) {
	return float3(LinearLight(base.r, blend.r), LinearLight(base.g, blend.g), LinearLight(base.b, blend.b));
}
float3 LinearLight(float3 base, float3 blend, float opacity) {
	return (LinearLight(base, blend) * opacity + base * (1.0 - opacity));
}

//Multiply
float3 Multiply(float3 base, float3 blend) {
	return base*blend;
}
float3 Multiply(float3 base, float3 blend, float opacity) {
	return (Multiply(base, blend) * opacity + base * (1.0 - opacity));
}

//Negation
float3 Negation(float3 base, float3 blend) {
	return float3(1.0, 1.0, 1.0) - abs(float3(1.0, 1.0, 1.0) - base - blend);
}
float3 Negation(float3 base, float3 blend, float opacity) {
	return (Negation(base, blend) * opacity + base * (1.0 - opacity));
}

//Normal
float3 Normal(float3 base, float3 blend) {
	return blend;
}
float3 Normal(float3 base, float3 blend, float opacity) {
	return (Normal(base, blend) * opacity + base * (1.0 - opacity));
}

//Phoenix
float3 Phoenix(float3 base, float3 blend) {
	return min(base, blend) - max(base, blend) + float3(1.0, 1.0, 1.0);
}
float3 Phoenix(float3 base, float3 blend, float opacity) {
	return (Phoenix(base, blend) * opacity + base * (1.0 - opacity));
}

//Pin Light
float PinLight(float base, float blend) {
	return (blend<0.5) ? Darken(base, (2.0*blend)) : Lighten(base, (2.0*(blend - 0.5)));
}
float3 PinLight(float3 base, float3 blend) {
	return float3(PinLight(base.r, blend.r), PinLight(base.g, blend.g), PinLight(base.b, blend.b));
}
float3 PinLight(float3 base, float3 blend, float opacity) {
	return (PinLight(base, blend) * opacity + base * (1.0 - opacity));
}

//Screen
float Screen(float base, float blend) {
	return 1.0 - ((1.0 - base)*(1.0 - blend));
}
float3 Screen(float3 base, float3 blend) {
	return float3(Screen(base.r, blend.r), Screen(base.g, blend.g), Screen(base.b, blend.b));
}
float3 Screen(float3 base, float3 blend, float opacity) {
	return (Screen(base, blend) * opacity + base * (1.0 - opacity));
}

//Soft Light
float SoftLight(float base, float blend) {
	return (blend<0.5) ? (2.0*base*blend + base*base*(1.0 - 2.0*blend)) : (sqrt(base)*(2.0*blend - 1.0) + 2.0*base*(1.0 - blend));
}
float3 SoftLight(float3 base, float3 blend) {
	return float3(SoftLight(base.r, blend.r), SoftLight(base.g, blend.g), SoftLight(base.b, blend.b));
}
float3 SoftLight(float3 base, float3 blend, float opacity) {
	return (SoftLight(base, blend) * opacity + base * (1.0 - opacity));
}

//Substract
float Substract(float base, float blend) {
	return max(base + blend - 1.0, 0.0);
}
float3 Substract(float3 base, float3 blend) {
	return max(base + blend - float3(1.0, 1.0, 1.0), float3(0.0, 0.0, 0.0));
}
float3 Substract(float3 base, float3 blend, float opacity) {
	return (Substract(base, blend) * opacity + blend * (1.0 - opacity));
}

//Subtract
float Subtract(float base, float blend) {
	return max(base - blend - 1.0, 0.0);
}
float3 Subtract(float3 base, float3 blend) {
	return max(base - blend, float3(0.0, 0.0, 0.0));
}
float3 Subtract(float3 base, float3 blend, float opacity) {
	return (Subtract(base, blend) * opacity + base * (1.0 - opacity));
}

